using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.Repositories;
using BeFit.Application.Services.Image;
using BeFit.Application.Services.Storage.Local;
using BeFit.Domain.Entities;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services.Image;

public class ImageService<T>(IRepository<T> repository,ILocalStorage storageService , IMapper mapper, IUnitOfWork uow) : IImageService<T> where T: Domain.Entities.Image
{
    
    public async Task<ServiceResponse<List<PostImageDto>>> Get()
    {
        var images = await repository.GetQueryable().ToListAsync();
        var dto = mapper.Map<List<PostImageDto>>(images);
        return ServiceResponse<List<PostImageDto>>.Success(dto, StatusCodes.Status200OK);
    }
    public async Task<ServiceResponse<NoContent>> Upload(IFormFileCollection files, Guid id, string path)
    {
        foreach (var formFile in files)
        {
            var image = DecideWhichType(formFile.FileName, id, path);
            await repository.CreateAsync((image as T)!);
        }
        await uow.SaveChangesAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status204NoContent);
    }
    public async Task<ServiceResponse<NoContent>> Delete(Guid id)
    {
        var postImage = await repository.GetByIdQueryable(id).FirstOrDefaultAsync();
        if (postImage == null)
            throw new NotFoundException("Image not found");
        repository.Delete(postImage);
        await uow.SaveChangesAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status204NoContent);
    }
    private static Domain.Entities.Image? DecideWhichType(string fileName, Guid id, string path)
    {
        return typeof(T) switch
        {
            { } t when t == typeof(PostImage) => new PostImage
            {
                FileName = fileName,
                PostId = id,
                Path = Path.Combine(path, fileName)
            },
            { } t when t == typeof(NutrientImage) => new NutrientImage
            {
                FileName = fileName,
                NutrientId = id,
                Path = Path.Combine(path, fileName)
            },
            { } t when t == typeof(CategoryImage) => new CategoryImage
            {
                FileName = fileName,
                Path = Path.Combine(path, fileName),
                CategoryId = id
            },
            _ => null
        };
    }
}
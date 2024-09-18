using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.DataTransferObjects.Post.CreateDtos;
using BeFit.Application.Repositories;
using BeFit.Application.Services.Image;
using BeFit.Application.Services.Post;
using BeFit.Domain.Entities;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services.Post
{
    public class PostService(IRepository<Domain.Entities.Post> repository, IUnitOfWork uow, IMapper mapper, IImageService<PostImage> imageService) : IPostService
    {
        public async Task<ServiceResponse<List<PostDto>>> Get(int page, int size)
        {
            var posts = await repository.GetQueryable()
                .Skip(page * size)
                .Take(size)
                    .Include(p => p.User)
                        .ThenInclude(u => u.Properties)
                    .Include(x => x.Likes)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Dislikes)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Comments)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Images).ToListAsync();

            var dto = mapper.Map<List<PostDto>>(posts);

            return ServiceResponse<List<PostDto>>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<PostDto>> GetById(Guid id)
        {
            var post = await repository.GetByIdQueryable(id)
                    .Include(p => p.User)
                        .ThenInclude(u => u.Properties)
                    .Include(x => x.Likes)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Dislikes)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Comments)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Images).FirstOrDefaultAsync();

            var dto = mapper.Map<PostDto>(post);

            return ServiceResponse<PostDto>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<List<PostDto>>> GetByUser(string id)
        {
            var posts = await repository.GetQueryable()
                .Where(x => x.UserId == id)
                   .Include(x => x.User)
                        .ThenInclude(x => x.Properties)
                   .Include(x => x.Likes)
                       .ThenInclude(x => x.User)
                   .Include(x => x.Dislikes)
                       .ThenInclude(x => x.User)
                   .Include(x => x.Comments)
                       .ThenInclude(x => x.User)
                   .Include(x => x.Images).ToListAsync();

            var dto = mapper.Map<List<PostDto>>(posts);

            return ServiceResponse<List<PostDto>>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<NoContent>> Create(CreatePostDto model)
        { 
            ArgumentNullException.ThrowIfNull(nameof(model));

            PostDto dto = new() { Id = Guid.NewGuid(), UserId = model.UserId, Title = model.Title, Description = model.Description }; 
            await repository.CreateAsync(mapper.Map<Domain.Entities.Post>(dto));
            await uow.SaveChangesAsync();
            
            await imageService.Upload(model.Images, dto.Id, "post-images");
            return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
        }
        public async Task<ServiceResponse<NoContent>> Update(UpdatePostDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            if (model.Id == Guid.Empty)
                return ServiceResponse<NoContent>.Failure("id is null or empty", StatusCodes.Status400BadRequest);

            var currentEntity = await repository.GetByIdQueryable(model.Id).FirstOrDefaultAsync()
                ?? throw new ArgumentNullException();

            currentEntity.Title = model.Title;
            currentEntity.Description = model.Description;

            repository.Update(currentEntity);
            await uow.SaveChangesAsync();

            return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
        }

        public async Task<ServiceResponse<NoContent>> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return ServiceResponse<NoContent>.Failure("id is null or empty", StatusCodes.Status400BadRequest);

            var currentEntity = await repository.GetByIdQueryable(id).FirstOrDefaultAsync() 
                ?? throw new NotFoundException("post not found");

            repository.Delete(currentEntity);
            await uow.SaveChangesAsync();
            return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
        }
    }
}

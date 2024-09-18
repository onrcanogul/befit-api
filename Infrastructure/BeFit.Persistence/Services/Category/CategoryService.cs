using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.DataTransferObjects.Create;
using BeFit.Application.DataTransferObjects.Update;
using BeFit.Application.Repositories;
using BeFit.Application.Services.Category;
using BeFit.Domain.Entities;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace BeFit.Persistence.Services
{
    public class CategoryService(IRepository<Category> repository, IMapper mapper, IUnitOfWork uow) : ICategoryService
    {
        public async Task<ServiceResponse<List<CategoryDto>>> Get()
        {
            var categories = await repository.GetQueryable()
                .Include(x => x.Drinks)
                    .ThenInclude(x => x.Properties)
                .Include(x => x.Foods)
                    .ThenInclude(x => x.Properties)
                 .Include(x => x.Images).ToListAsync();

            var list = mapper.Map<List<CategoryDto>>(categories);

            return ServiceResponse<List<CategoryDto>>.Success(list, StatusCodes.Status200OK);
        }

        public async Task<ServiceResponse<CategoryDto>> GetById(Guid id)
        {
            var category = await repository.GetByIdQueryable(id)
                .Include(x => x.Drinks)
                    .ThenInclude(x => x.Properties)
                .Include(x => x.Foods)
                    .ThenInclude(x => x.Properties)
                 .Include(x => x.Images).FirstOrDefaultAsync();

            var list = mapper.Map<CategoryDto>(category);

            return ServiceResponse<CategoryDto>.Success(list, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<NoContent>> Create(CreateCategoryDto model)
        {
            var mapping = mapper.Map<Category>(model);
            await repository.CreateAsync(mapping);
            await uow.SaveChangesAsync();
            return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
        }
        public async Task<ServiceResponse<NoContent>> Update(UpdateCategoryDto model)
        {
            var existModel = await repository.GetByIdQueryable(model.Id).FirstOrDefaultAsync() ?? throw new NotFoundException("category not found");
            existModel.Name = model.Name;
            existModel.Description = model.Description;
            repository.Update(existModel);
            await uow.SaveChangesAsync();
            return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<NoContent>> Delete(Guid id)
        {
            var existModel = await repository.GetByIdQueryable(id).FirstOrDefaultAsync() ?? throw new ArgumentNullException();

            repository.Delete(existModel);

            await uow.SaveChangesAsync();

            return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
        }
     
    }
}

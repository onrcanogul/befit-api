using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.Repositories;
using BeFit.Application.Services.Category;
using BeFit.Domain.Entities;
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
        public async Task<ServiceResponse<NoContent>> Create(CategoryDto model)
        {
            var mapping = mapper.Map<Category>(model);

            await repository.CreateAsync(mapping);
            await uow.SaveChangesAsync();

            return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
        }
        public async Task<ServiceResponse<NoContent>> Update(CategoryDto model)
        {
            var existModel = await repository.GetByIdQueryable(model.Id).FirstOrDefaultAsync();
            var mapping = mapper.Map(model, existModel) ?? throw new ArgumentNullException();;
            
            repository.Update(mapping);
            await uow.SaveChangesAsync();

            return ServiceResponse<NoContent>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<ServiceResponse<NoContent>> Delete(Guid id)
        {
            var existModel = await repository.GetByIdQueryable(id).FirstOrDefaultAsync() ?? throw new ArgumentNullException();

            repository.Delete(existModel);

            await uow.SaveChangesAsync();

            return ServiceResponse<NoContent>.Success(StatusCodes.Status204NoContent);
        }
     
    }
}

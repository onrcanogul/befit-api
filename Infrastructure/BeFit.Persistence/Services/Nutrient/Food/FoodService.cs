using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.DataTransferObjects.Nutrients.CreateDtos;
using BeFit.Application.Repositories;
using BeFit.Application.Services;
using BeFit.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services
{
    public class FoodService(IRepository<Food> Repository, IMapper mapper, IUnitOfWork uow) : IFoodService
    {
        public async Task<ServiceResponse<List<FoodDto>>> GetAll(int page, int size)
        {
            List<Food> list = await Repository.GetQueryable()
                .Include(f => f.Properties)
                .ToListAsync();

            List<FoodDto> foods = mapper.Map<List<FoodDto>>(list);
            return ServiceResponse<List<FoodDto>>.Success(foods, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<FoodDto>> GetById(Guid id)
        {
            var food = await Repository.GetByIdQueryable(id)
                .Include(f => f.Properties)
                .FirstOrDefaultAsync();
            var dto = mapper.Map<FoodDto>(food);

            return ServiceResponse<FoodDto>.Success(dto, StatusCodes.Status200OK);
        }

        public async Task<ServiceResponse<FoodDto>> Create(CreateNutrientDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var mappingResult = mapper.Map<Food>(model);

            await Repository.CreateAsync(mappingResult);

            await uow.SaveChangesAsync();

            var dto = mapper.Map<FoodDto>(mappingResult);

            return ServiceResponse<FoodDto>.Success(dto, StatusCodes.Status201Created);
        }

        public async Task<ServiceResponse<NoContent>> Delete(Guid id)
        {
            var existEntity = await Repository.GetByIdQueryable(id).FirstOrDefaultAsync() ?? throw new ArgumentNullException();

            Repository.Delete(existEntity);

            await uow.SaveChangesAsync();

            return ServiceResponse<NoContent>.Success(StatusCodes.Status204NoContent);
        }
        public async Task<ServiceResponse<NoContent>> Update(UpdateNutrientDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var oldEntity = await Repository.GetByIdQueryable(model.Id).FirstOrDefaultAsync() ?? throw new ArgumentNullException(nameof(model));

            var entity = mapper.Map(model, oldEntity);

            entity.Id = oldEntity.Id;
            entity.CreatedDate = oldEntity.CreatedDate;

            Repository.Update(entity);

            await uow.SaveChangesAsync();

            return ServiceResponse<NoContent>.Success(StatusCodes.Status204NoContent);
        }
    }
}

using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.DataTransferObjects.Nutrients.CreateDtos;
using BeFit.Application.Repositories;
using BeFit.Application.Services.Nutrient;
using BeFit.Application.Services.NutrientProperty;
using BeFit.Domain.Entities;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services.Nutrient;

public class NutrientService<T, TDto>(IRepository<T> Repository, IMapper mapper, IUnitOfWork uow, INutrientPropertyService propertyService) : INutrientService<T,TDto> where T : Domain.Entities.Abstract.Nutrient where TDto : NutrientDto
{
        public async Task<ServiceResponse<List<TDto>>> GetAll(int page, int size)
        {
            var list = await Repository.GetQueryable().Include(f => f.Properties).ToListAsync();
            var foods = mapper.Map<List<TDto>>(list);
            return ServiceResponse<List<TDto>>.Success(foods, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<TDto>> GetById(Guid id)
        {
            var food = await Repository.GetByIdQueryable(id).Include(f => f.Properties).FirstOrDefaultAsync();
            var dto = mapper.Map<TDto>(food);
            return ServiceResponse<TDto>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<NoContent>> Create(CreateNutrientDto model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var nutrient = GetNutrient(model) as T ?? throw new NotFoundException("Nutrient not found");
            await Repository.CreateAsync(nutrient);
            await uow.SaveChangesAsync();
            await propertyService.Create(model.Properties, nutrient.Id); //save changes in ps 
            return ServiceResponse<NoContent>.Success(null, StatusCodes.Status201Created);
        }
        public async Task<ServiceResponse<NoContent>> Delete(Guid id)
        {
            var existEntity = await Repository.GetByIdQueryable(id).FirstOrDefaultAsync() ?? throw new NotFoundException(typeof(T) + " not found");
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
            return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
        }
        private static Domain.Entities.Abstract.Nutrient GetNutrient(CreateNutrientDto model)
        {
            return typeof(T) switch
            {
                { } t when t == typeof(Food) => new Food { Id = Guid.NewGuid(), Name = model.Name, Description = model.Description },
                { } t when t == typeof(Drink) => new Drink { Id = Guid.NewGuid(), Name = model.Name, Description = model.Description },
                _ => throw new NotFoundException("Type not found")
            };
        } 
}
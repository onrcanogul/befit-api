using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.DataTransferObjects.Nutrients.CreateDtos;
using BeFit.Application.Repositories;
using BeFit.Application.Services.Nutrient;
using BeFit.Application.Services.NutrientProperty;
using BeFit.Domain.Entities;
using BeFit.Infrastructure.Exceptions;
using BeFit.Persistence.Extensions;
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
        public async Task<ServiceResponse<List<TDto>>> Filter(FilterNutrientDto model)
        {
            var query = Repository.GetQueryable().Include(x => x.Properties).OrderBy(x => x.Name)
                .WhereIf(model.Term != null, x => x.Name.Contains(model.Term) || x.Description.Contains(model.Term))
                .WhereIf(model.CategoryIds.Count > 0, x => x.Categories.Any(y => y.Id == model.CategoryIds.First()))
                .WhereIf(model.MaxCalorie != null, x => x.Properties.Calories <= model.MaxCalorie)
                .WhereIf(model.MinCalorie != null, x => x.Properties.Calories >= model.MinCalorie);
            var nutrients = mapper.Map<List<TDto>>(await query.ToListAsync());
            return ServiceResponse<List<TDto>>.Success(nutrients, StatusCodes.Status200OK);
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
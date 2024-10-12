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

public class NutrientService(IRepository<Domain.Entities.Abstract.Nutrient> Repository, IMapper mapper, IUnitOfWork uow, INutrientPropertyService propertyService) : INutrientService
{
        public async Task<ServiceResponse<List<NutrientDto>>> GetAll(int page, int size)
        {
            var list = await Repository.GetQueryable().Include(f => f.Properties).ToListAsync();
            var foods = mapper.Map<List<NutrientDto>>(list);
            return ServiceResponse<List<NutrientDto>>.Success(foods, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<NutrientDto>> GetById(Guid id)
        {
            var food = await Repository.GetByIdQueryable(id).Include(f => f.Properties).FirstOrDefaultAsync();
            var dto = mapper.Map<NutrientDto>(food);
            return ServiceResponse<NutrientDto>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<NoContent>> Create(CreateNutrientDto model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var nutrient = mapper.Map<Domain.Entities.Abstract.Nutrient>(model);
            await Repository.CreateAsync(nutrient);
            await uow.SaveChangesAsync();
            await propertyService.Create(model.Properties, nutrient.Id); //save changes in ps 
            return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
        }
        public async Task<ServiceResponse<NoContent>> Delete(Guid id)
        {
            var existEntity = await Repository.GetByIdQueryable(id).FirstOrDefaultAsync() ?? throw new NotFoundException("Nutrient not found");
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
        public async Task<ServiceResponse<List<NutrientDto>>> Filter(FilterNutrientDto model)
        {
            var query = Repository.GetQueryable().Include(x => x.Properties).OrderBy(x => x.Name)
                .WhereIf(model.Term != null, x => x.Name.Contains(model.Term) || x.Description.Contains(model.Term))
                .WhereIf(model.CategoryIds.Count > 0, x => x.Categories.Any(y => y.Id == model.CategoryIds.First()))
                .WhereIf(model.MaxCalorie != null, x => x.Properties.Calories <= model.MaxCalorie)
                .WhereIf(model.MinCalorie != null, x => x.Properties.Calories >= model.MinCalorie);
            var nutrients = mapper.Map<List<NutrientDto>>(await query.ToListAsync());
            return ServiceResponse<List<NutrientDto>>.Success(nutrients, StatusCodes.Status200OK);
        }
}
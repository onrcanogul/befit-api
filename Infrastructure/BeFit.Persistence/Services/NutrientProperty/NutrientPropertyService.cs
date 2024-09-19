using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.Repositories;
using BeFit.Application.Services.NutrientProperty;
using BeFit.Domain.Entities;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services.NutrientProperty;

public class NutrientPropertyService(IRepository<NutrientProperties> repository, IMapper mapper, IUnitOfWork uow) : INutrientPropertyService
{

    public async Task<ServiceResponse<NoContent>> Create(NutrientPropertiesDto model, Guid nutrientId)
    {
        var np = mapper.Map<NutrientProperties>(model);
        np.NutrientId = nutrientId;
        await repository.CreateAsync(np);
        await uow.SaveChangesAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
    }
    public async Task<ServiceResponse<NoContent>> Update(NutrientPropertiesDto newChanges)
    {
        var nutrientProperty = await repository.GetByIdQueryable(newChanges.Id).FirstOrDefaultAsync() ?? throw new NotFoundException("Nutrient Property Not Found");
        var np = mapper.Map(newChanges, nutrientProperty);
        repository.Update(np);
        await uow.SaveChangesAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status204NoContent);
    }
    public async Task<ServiceResponse<NoContent>> Delete(Guid id)
    {
        var np = await repository.GetByIdQueryable(id).FirstOrDefaultAsync();
        if (np == null) throw new NotFoundException("Nutrient Property not found");
        repository.Delete(np);
        await uow.SaveChangesAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status204NoContent);
    }

}
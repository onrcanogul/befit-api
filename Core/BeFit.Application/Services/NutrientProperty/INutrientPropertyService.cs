using BeFit.Domain.Entities;

namespace BeFit.Application.Services.NutrientProperty;

public interface INutrientPropertyService
{
    Task<ServiceResponse<NoContent>> Create(NutrientPropertiesDto model, Guid nutrientId);
    Task<ServiceResponse<NoContent>> Update(NutrientPropertiesDto newChanges);
    Task<ServiceResponse<NoContent>> Delete(Guid id);
}
using BeFit.Application.DataTransferObjects.Nutrients.CreateDtos;

namespace BeFit.Application.Services.Nutrient;

public interface INutrientService
{
    Task<ServiceResponse<List<NutrientDto>>> GetAll(int page, int size);
    Task<ServiceResponse<NutrientDto>> GetById(Guid id);
    Task<ServiceResponse<NoContent>> Create(CreateNutrientDto model);
    Task<ServiceResponse<NoContent>> Delete(Guid id);
    Task<ServiceResponse<NoContent>> Update(UpdateNutrientDto model);
    Task<ServiceResponse<List<NutrientDto>>> Filter(FilterNutrientDto model);
}
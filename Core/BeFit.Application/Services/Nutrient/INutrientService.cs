using BeFit.Application.DataTransferObjects.Nutrients.CreateDtos;

namespace BeFit.Application.Services.Nutrient;

public interface INutrientService<T,TDto> where T : Domain.Entities.Abstract.Nutrient where TDto : NutrientDto
{
    Task<ServiceResponse<List<TDto>>> GetAll(int page, int size);
    Task<ServiceResponse<TDto>> GetById(Guid id);
    Task<ServiceResponse<NoContent>> Create(CreateNutrientDto model);
    Task<ServiceResponse<NoContent>> Delete(Guid id);
    Task<ServiceResponse<NoContent>> Update(UpdateNutrientDto model);
}
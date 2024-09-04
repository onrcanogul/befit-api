using BeFit.Application.DataTransferObjects.Nutrients.CreateDtos;

namespace BeFit.Application.Services
{
    public interface IFoodService
    {
        Task<ServiceResponse<List<FoodDto>>> GetAll(int page, int size);
        Task<ServiceResponse<FoodDto>> GetById(Guid id);
        Task<ServiceResponse<FoodDto>> Create(CreateNutrientDto model);
        Task<ServiceResponse<NoContent>> Update(UpdateNutrientDto model);
        Task<ServiceResponse<NoContent>> Delete(Guid id);
    }
}

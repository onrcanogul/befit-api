using BeFit.Application.DataTransferObjects;
using BeFit.Application.DataTransferObjects.Nutrients.CreateDtos;

namespace BeFit.Application.Services
{
    public interface IFoodService
    {
        Task<List<FoodDto>> GetAll(int page, int size);
        Task<FoodDto> GetById(Guid id);
        Task<FoodDto> Create(CreateNutrientDto model);
        Task Update(UpdateNutrientDto model);
        Task Delete(Guid id);
    }
}

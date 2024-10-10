using BeFit.Application.DataTransferObjects.FoodBasket;

namespace BeFit.Application.Services.FoodBasket;

public interface IFoodBasketService
{
    Task<ServiceResponse<FoodBasketDto>> Get(string userId);
    Task<ServiceResponse<NoContent>> Create(string userId);
    Task<ServiceResponse<NoContent>> Clear(Guid basketId);
}
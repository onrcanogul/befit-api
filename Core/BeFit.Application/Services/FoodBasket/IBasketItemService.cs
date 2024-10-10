using BeFit.Application.DataTransferObjects.FoodBasket;

namespace BeFit.Application.Services.FoodBasket;

public interface IBasketItemService
{
    Task<ServiceResponse<NoContent>> Add(AddItemDto model);
    Task<ServiceResponse<NoContent>> Delete(Guid id);
    Task<ServiceResponse<NoContent>> Update(Guid id, Guid nutrientId, decimal measure);
}
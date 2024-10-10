using BeFit.Application.DataTransferObjects.FoodBasket;
using BeFit.Application.Services.FoodBasket;

namespace BeFit.Application.Features.BasketItem.Command;
public record AddBasketItemRequest(AddItemDto Model) : IRequest<AddBasketItemResponse>;
public record AddBasketItemResponse(ServiceResponse<NoContent> Response);
public class AddBasketItemHandler(IBasketItemService service) : IRequestHandler<AddBasketItemRequest, AddBasketItemResponse>
{
    public async Task<AddBasketItemResponse> Handle(AddBasketItemRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Add(request.Model));
    }
}
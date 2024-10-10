using BeFit.Application.Services.FoodBasket;

namespace BeFit.Application.Features.BasketItem.Command.Delete;

public record DeleteBasketItemRequest(Guid Id) : IRequest<DeleteBasketItemResponse>;

public record DeleteBasketItemResponse(ServiceResponse<NoContent> Response);
public class DeleteBasketItemHandler(IBasketItemService service) : IRequestHandler<DeleteBasketItemRequest, DeleteBasketItemResponse>
{
    public async Task<DeleteBasketItemResponse> Handle(DeleteBasketItemRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Delete(request.Id));
    }
}
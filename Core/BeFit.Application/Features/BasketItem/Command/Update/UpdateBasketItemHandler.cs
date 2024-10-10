using BeFit.Application.Services.FoodBasket;

namespace BeFit.Application.Features.BasketItem.Command.Update;

public record UpdateBasketItemRequest(Guid Id, Guid NutrientId, Decimal Measure) : IRequest<UpdateBasketItemResponse>;

public record UpdateBasketItemResponse(ServiceResponse<NoContent> Response);
public class UpdateBasketItemHandler(IBasketItemService service) : IRequestHandler<UpdateBasketItemRequest, UpdateBasketItemResponse>
{
    public async Task<UpdateBasketItemResponse> Handle(UpdateBasketItemRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Update(request.Id, request.NutrientId, request.Measure));
    }
}
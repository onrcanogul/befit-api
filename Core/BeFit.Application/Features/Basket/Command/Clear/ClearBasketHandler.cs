using BeFit.Application.Services.FoodBasket;

namespace BeFit.Application.Features.Basket.Command.Clear;

public record ClearBasketRequest(Guid BasketId) : IRequest<ClearBasketResponse>;

public record ClearBasketResponse(ServiceResponse<NoContent> Response);


public class ClearBasketHandler(IFoodBasketService service) : IRequestHandler<ClearBasketRequest, ClearBasketResponse>
{
    public async Task<ClearBasketResponse> Handle(ClearBasketRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Clear(request.BasketId));
    }
}
using BeFit.Application.DataTransferObjects.FoodBasket;
using BeFit.Application.Services.FoodBasket;

namespace BeFit.Application.Features.Basket.Query.Get;

public record GetBasketRequest(string UserId) : IRequest<GetBasketResponse>;

public record GetBasketResponse(ServiceResponse<FoodBasketDto> Response);

public class GetBasketHandler(IFoodBasketService service) : IRequestHandler<GetBasketRequest, GetBasketResponse>
{
    public async Task<GetBasketResponse> Handle(GetBasketRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Get(request.UserId));
    }
}
using BeFit.Application.DataTransferObjects.FoodBasket;
using BeFit.Application.Services.FoodBasket;

namespace BeFit.Application.Features.Basket.Command.Save;

public record SaveBasketRequest(SaveBasketDto Model) : IRequest<SaveBasketResponse>;
public record SaveBasketResponse(ServiceResponse<FoodBasketDto> Response);
public class SaveBasketHandler(IFoodBasketService service) : IRequestHandler<SaveBasketRequest, SaveBasketResponse>
{
    public async Task<SaveBasketResponse> Handle(SaveBasketRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Save(request.Model));
    }
}
using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Drink.Query.Get;

public record GetDrinksRequest(int Page, int Size) : IRequest<GetDrinksResponse>;

public record GetDrinksResponse(ServiceResponse<List<DrinkDto>> Response);
public class GetDrinksHandler(INutrientService<Domain.Entities.Drink, DrinkDto> service) : IRequestHandler<GetDrinksRequest, GetDrinksResponse>
{
    public async Task<GetDrinksResponse> Handle(GetDrinksRequest request, CancellationToken cancellationToken)
    {
        return new(await service.GetAll(request.Page, request.Size));
    }
}
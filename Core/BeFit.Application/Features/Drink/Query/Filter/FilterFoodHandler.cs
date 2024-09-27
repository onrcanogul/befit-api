using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Food.Query.Filter;

public record FilterDrinkRequest(FilterNutrientDto Model) : IRequest<FilterDrinkResponse>;

public record FilterDrinkResponse(ServiceResponse<List<DrinkDto>> Response);

public class FilterDrinkHandler(INutrientService<Domain.Entities.Drink, DrinkDto> service) : IRequestHandler<FilterDrinkRequest, FilterDrinkResponse>
{
    public async Task<FilterDrinkResponse> Handle(FilterDrinkRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Filter(request.Model));
    }
}
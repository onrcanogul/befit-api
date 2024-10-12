using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Food.Query.Filter;

public record FilterFoodRequest(FilterNutrientDto Model) : IRequest<FilterFoodResponse>;

public record FilterFoodResponse(ServiceResponse<List<NutrientDto>> Response);

public class FilterFoodHandler(INutrientService service) : IRequestHandler<FilterFoodRequest, FilterFoodResponse>
{
    public async Task<FilterFoodResponse> Handle(FilterFoodRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Filter(request.Model));
    }
}
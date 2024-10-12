using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Food.Query.Get;

public record GetFoodsRequest(int Page, int Size) : IRequest<GetFoodsResponse>;
public record GetFoodsResponse(ServiceResponse<List<NutrientDto>> Response);
public class GetFoodsHandler(INutrientService service) : IRequestHandler<GetFoodsRequest, GetFoodsResponse>
{
    public async Task<GetFoodsResponse> Handle(GetFoodsRequest request, CancellationToken cancellationToken)
    {
        return new(await service.GetAll(request.Page, request.Size));
    }
}
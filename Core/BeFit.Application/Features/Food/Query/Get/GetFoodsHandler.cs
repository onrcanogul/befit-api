using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Food.Query.Get;

public record GetFoodsRequest(int Page, int Size) : IRequest<GetFoodsResponse>;
public record GetFoodsResponse(ServiceResponse<List<FoodDto>> Response);
public class GetFoodsHandler(INutrientService<Domain.Entities.Food,FoodDto> service) : IRequestHandler<GetFoodsRequest, GetFoodsResponse>
{
    public async Task<GetFoodsResponse> Handle(GetFoodsRequest request, CancellationToken cancellationToken)
    {
        return new(await service.GetAll(request.Page, request.Size));
    }
}
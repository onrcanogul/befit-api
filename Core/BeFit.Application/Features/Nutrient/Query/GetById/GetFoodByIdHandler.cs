using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Food.Query.GetById;

public record GetFoodByIdRequest(Guid Id) : IRequest<GetFoodByIdResponse>;

public record GetFoodByIdResponse(ServiceResponse<NutrientDto> Response);
public class GetFoodByIdHandler(INutrientService service) : IRequestHandler<GetFoodByIdRequest, GetFoodByIdResponse>
{
    public async Task<GetFoodByIdResponse> Handle(GetFoodByIdRequest request, CancellationToken cancellationToken)
    {
        return new(await service.GetById(request.Id));
    }
}
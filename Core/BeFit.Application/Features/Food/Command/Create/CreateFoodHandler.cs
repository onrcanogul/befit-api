using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Food.Command.Create;

public record CreateFoodRequest(CreateNutrientDto Model) : IRequest<CreateFoodResponse>;

public record CreateFoodResponse(ServiceResponse<NoContent> Response);


public class CreateFoodHandler(INutrientService<Domain.Entities.Food,FoodDto> service) : IRequestHandler<CreateFoodRequest, CreateFoodResponse>
{
    public async Task<CreateFoodResponse> Handle(CreateFoodRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Create(request.Model));
    }
}
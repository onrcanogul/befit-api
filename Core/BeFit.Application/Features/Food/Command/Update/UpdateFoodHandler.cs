using BeFit.Application.DataTransferObjects.Nutrients.CreateDtos;
using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Food.Command.Update;
public record UpdateFoodRequest(UpdateNutrientDto Model) : IRequest<UpdateFoodResponse>;

public record UpdateFoodResponse(ServiceResponse<NoContent> Response);

public class UpdateFoodHandler(INutrientService<Domain.Entities.Food,FoodDto> service) : IRequestHandler<UpdateFoodRequest, UpdateFoodResponse>
{
    public async Task<UpdateFoodResponse> Handle(UpdateFoodRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Update(request.Model));
    }
}
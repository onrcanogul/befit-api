using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Food.Command.Delete;
public record DeleteFoodRequest(Guid Id) : IRequest<DeleteFoodResponse>;

public record DeleteFoodResponse(ServiceResponse<NoContent> Response);

public class DeleteFoodHandler(INutrientService<Domain.Entities.Food,FoodDto> service) : IRequestHandler<DeleteFoodRequest, DeleteFoodResponse>
{
    public async Task<DeleteFoodResponse> Handle(DeleteFoodRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Delete(request.Id));
    }
}
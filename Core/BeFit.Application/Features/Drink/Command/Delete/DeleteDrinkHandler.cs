using BeFit.Application.Services.Nutrient;
namespace BeFit.Application.Features.Drink.Command.Delete;

public record DeleteDrinkRequest(Guid Id) : IRequest<DeleteDrinkResponse>;
public record DeleteDrinkResponse(ServiceResponse<NoContent> Response);

public class DeleteDrinkHandler(INutrientService<Domain.Entities.Drink, DrinkDto> service) : IRequestHandler<DeleteDrinkRequest, DeleteDrinkResponse>
{
    public async Task<DeleteDrinkResponse> Handle(DeleteDrinkRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Delete(request.Id));
    }
}
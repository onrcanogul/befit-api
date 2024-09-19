using BeFit.Application.DataTransferObjects.Nutrients.CreateDtos;
using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Drink.Command.Update;

public record UpdateDrinkRequest(UpdateNutrientDto Model) : IRequest<UpdateDrinkResponse>;
public record UpdateDrinkResponse(ServiceResponse<NoContent> Response);
public class UpdateDrinkHandler(INutrientService<Domain.Entities.Drink, DrinkDto> service) : IRequestHandler<UpdateDrinkRequest, UpdateDrinkResponse>
{
    public async Task<UpdateDrinkResponse> Handle(UpdateDrinkRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Update(request.Model));
    }
}
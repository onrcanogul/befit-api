using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Drink.Command.Create;

public record CreateDrinkRequest(CreateNutrientDto Model) : IRequest<CreateDrinkResponse>;

public record CreateDrinkResponse(ServiceResponse<NoContent> Response);


public class CreateDrinkHandler(INutrientService<Domain.Entities.Drink,DrinkDto> service) : IRequestHandler<CreateDrinkRequest, CreateDrinkResponse>
{
    public async Task<CreateDrinkResponse> Handle(CreateDrinkRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Create(request.Model).ConfigureAwait(false));
    }
}
using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Drink.Query.GetById;

public record GetDrinkByIdRequest(Guid Id) : IRequest<GetDrinkByIdResponse>;
public record GetDrinkByIdResponse(ServiceResponse<DrinkDto> Response);
public class GetDrinkByIdHandler(INutrientService<Domain.Entities.Drink, DrinkDto> service) : IRequestHandler<GetDrinkByIdRequest, GetDrinkByIdResponse>
{
    public async Task<GetDrinkByIdResponse> Handle(GetDrinkByIdRequest request, CancellationToken cancellationToken)
    {
        return new(await service.GetById(request.Id));
    }
}
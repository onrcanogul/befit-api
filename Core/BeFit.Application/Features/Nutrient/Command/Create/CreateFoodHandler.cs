using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Food.Command.Create;

public record CreateNutrientRequest(CreateNutrientDto Model) : IRequest<CreateNutrientResponse>;

public record CreateNutrientResponse(ServiceResponse<NoContent> Response);


public class CreateNutrientHandler(INutrientService service) : IRequestHandler<CreateNutrientRequest, CreateNutrientResponse>
{
    public async Task<CreateNutrientResponse> Handle(CreateNutrientRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Create(request.Model));
    }
}
using BeFit.Application.DataTransferObjects.Nutrients.CreateDtos;
using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Food.Command.Update;
public record UpdateNutrientRequest(UpdateNutrientDto Model) : IRequest<UpdateNutrientResponse>;

public record UpdateNutrientResponse(ServiceResponse<NoContent> Response);

public class UpdateNutrientHandler(INutrientService service) : IRequestHandler<UpdateNutrientRequest, UpdateNutrientResponse>
{
    public async Task<UpdateNutrientResponse> Handle(UpdateNutrientRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Update(request.Model));
    }
}
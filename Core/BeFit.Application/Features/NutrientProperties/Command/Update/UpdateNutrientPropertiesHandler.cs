using BeFit.Application.Services.NutrientProperty;

namespace BeFit.Application.Features.NutrientProperties.Command.Update;

public record UpdateNutrientPropertiesRequest(NutrientPropertiesDto Model) : IRequest<UpdateNutrientPropertiesResponse>;
public record UpdateNutrientPropertiesResponse(ServiceResponse<NoContent> Response);

public class UpdateNutrientPropertiesHandler(INutrientPropertyService service) : IRequestHandler<UpdateNutrientPropertiesRequest, UpdateNutrientPropertiesResponse>
{
    public async Task<UpdateNutrientPropertiesResponse> Handle(UpdateNutrientPropertiesRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Update(request.Model));
    }
}
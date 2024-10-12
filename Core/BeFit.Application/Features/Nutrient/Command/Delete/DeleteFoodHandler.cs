using BeFit.Application.Services.Nutrient;

namespace BeFit.Application.Features.Food.Command.Delete;
public record DeleteNutrientRequest(Guid Id) : IRequest<DeleteNutrientResponse>;

public record DeleteNutrientResponse(ServiceResponse<NoContent> Response);

public class DeleteNutrientHandler(INutrientService service) : IRequestHandler<DeleteNutrientRequest, DeleteNutrientResponse>
{
    public async Task<DeleteNutrientResponse> Handle(DeleteNutrientRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Delete(request.Id));
    }
}
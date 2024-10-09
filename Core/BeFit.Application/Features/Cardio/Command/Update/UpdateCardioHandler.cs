using BeFit.Application.Services.Exercise;
namespace BeFit.Application.Features.Cardio.Command;
public record UpdateCardioRequest(string UserId, Guid ExerciseId, decimal Minutes) : IRequest<UpdateCardioResponse>;
public record UpdateCardioResponse(ServiceResponse<NoContent> Response);
public class UpdateCardioHandler(ICardioService service) : IRequestHandler<UpdateCardioRequest, UpdateCardioResponse>
{
    public async Task<UpdateCardioResponse> Handle(UpdateCardioRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Update(request.UserId, request.ExerciseId, request.Minutes));
    }
}
using BeFit.Application.Services.Exercise;
namespace BeFit.Application.Features.Cardio.Command;
public record DeleteCardioRequest(string UserId, Guid ExerciseId) : IRequest<DeleteCardioResponse>;
public record DeleteCardioResponse(ServiceResponse<NoContent> Response);
public class DeleteCardioHandler(ICardioService service) : IRequestHandler<DeleteCardioRequest, DeleteCardioResponse>
{
    public async Task<DeleteCardioResponse> Handle(DeleteCardioRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Delete(request.UserId, request.ExerciseId));
    }
}
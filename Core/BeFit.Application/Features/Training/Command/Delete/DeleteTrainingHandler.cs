using BeFit.Application.Services.Exercise;
namespace BeFit.Application.Features.Training;
public record DeleteTrainingRequest(string UserId, Guid ExerciseId) : IRequest<DeleteTrainingResponse>;
public record DeleteTrainingResponse(ServiceResponse<NoContent> Response);
public class DeleteTrainingHandler(ICardioService service) : IRequestHandler<DeleteTrainingRequest, DeleteTrainingResponse>
{
    public async Task<DeleteTrainingResponse> Handle(DeleteTrainingRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Delete(request.UserId, request.ExerciseId));
    }
}
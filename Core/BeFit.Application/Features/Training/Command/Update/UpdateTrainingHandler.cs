using BeFit.Application.Services.Exercise;
namespace BeFit.Application.Features.Cardio.Training;
public record UpdateTrainingRequest(string UserId, Guid ExerciseId, int Reps) : IRequest<UpdateTrainingResponse>;
public record UpdateTrainingResponse(ServiceResponse<NoContent> Response);
public class UpdateTrainingHandler(ITrainingService service) : IRequestHandler<UpdateTrainingRequest, UpdateTrainingResponse>
{
    public async Task<UpdateTrainingResponse> Handle(UpdateTrainingRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Update(request.UserId, request.ExerciseId, request.Reps));
    }
}
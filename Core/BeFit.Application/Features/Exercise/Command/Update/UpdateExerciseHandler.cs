using BeFit.Application.Services.Exercise;
namespace BeFit.Application.Features.Exercise.Command.Delete;
public record UpdateExerciseRequest(ExerciseDto Model) : IRequest<UpdateExerciseResponse>;
public record UpdateExerciseResponse(ServiceResponse<NoContent> Response);
public class UpdateExerciseHandler(IExerciseService<Domain.Entities.Exercise.Exercise, ExerciseDto> service) : IRequestHandler<UpdateExerciseRequest, UpdateExerciseResponse>
{
    public async Task<UpdateExerciseResponse> Handle(UpdateExerciseRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Update(request.Model));
    }
}
using BeFit.Application.Services.Exercise;
namespace BeFit.Application.Features.Exercise.Command.Delete;
public record DeleteExerciseRequest(Guid Id) : IRequest<DeleteExerciseResponse>;
public record DeleteExerciseResponse(ServiceResponse<NoContent> Response);
public class DeleteExerciseHandler(IExerciseService<Domain.Entities.Exercise.Exercise, ExerciseDto> service) : IRequestHandler<DeleteExerciseRequest, DeleteExerciseResponse>
{
    public async Task<DeleteExerciseResponse> Handle(DeleteExerciseRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Delete(request.Id));
    }
}
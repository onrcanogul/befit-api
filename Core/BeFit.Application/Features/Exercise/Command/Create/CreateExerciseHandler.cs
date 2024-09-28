using BeFit.Application.Services.Exercise;
namespace BeFit.Application.Features.Exercise.Command.Create;
public record CreateExerciseRequest(ExerciseDto Model) : IRequest<CreateExerciseResponse>;
public record CreateExerciseResponse(ServiceResponse<NoContent> Response);
public class CreateExerciseHandler(IExerciseService<Domain.Entities.Exercise.Exercise, ExerciseDto> service) : IRequestHandler<CreateExerciseRequest, CreateExerciseResponse>
{
    public async Task<CreateExerciseResponse> Handle(CreateExerciseRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Create(request.Model));
    }
}
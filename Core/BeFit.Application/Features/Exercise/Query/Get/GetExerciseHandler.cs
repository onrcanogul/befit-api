using BeFit.Application.Services.Exercise;
namespace BeFit.Application.Features.Exercise.Query.Get;

public record GetExerciseRequest(int Page, int Size) : IRequest<GetExerciseResponse>;

public record GetExerciseResponse(ServiceResponse<List<ExerciseDto>> Response);

public class GetExerciseHandler(IExerciseService<Domain.Entities.Exercise.Exercise, ExerciseDto> service) : IRequestHandler<GetExerciseRequest, GetExerciseResponse>
{
    public async Task<GetExerciseResponse> Handle(GetExerciseRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Get(request.Page, request.Size));
    }
}
using BeFit.Application.Services.Exercise;

namespace BeFit.Application.Features.Exercise.Query.GetId;

public record GetExerciseByIdRequest(Guid Id) : IRequest<GetExerciseByIdResponse>;
public record GetExerciseByIdResponse(ServiceResponse<ExerciseDto> Response);
public class GetExerciseByIdHandler(IExerciseService<Domain.Entities.Exercise.Exercise, ExerciseDto> service) : IRequestHandler<GetExerciseByIdRequest, GetExerciseByIdResponse>
{
    public async Task<GetExerciseByIdResponse> Handle(GetExerciseByIdRequest request, CancellationToken cancellationToken)
    {
        return new(await service.GetById(request.Id));
    }
}
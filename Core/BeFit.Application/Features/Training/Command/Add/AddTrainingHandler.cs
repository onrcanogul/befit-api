using BeFit.Application.Services.Exercise;
namespace BeFit.Application.Features.Training;
public record AddTrainingRequest(string UserId, TrainingDto Model) : IRequest<AddTrainingResponse>;
public record AddTrainingResponse(ServiceResponse<NoContent> Response);
public class AddTrainingHandler(ITrainingService service) : IRequestHandler<AddTrainingRequest, AddTrainingResponse>
{
    public async Task<AddTrainingResponse> Handle(AddTrainingRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Add(request.UserId, request.Model));
    }
}
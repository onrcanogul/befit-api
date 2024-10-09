using BeFit.Application.Services.Exercise;
namespace BeFit.Application.Features.Cardio.Command;
public record AddCardioRequest(string UserId, CardioDto Model) : IRequest<AddCardioResponse>;
public record AddCardioResponse(ServiceResponse<NoContent> Response);
public class AddCardioHandler(ICardioService service) : IRequestHandler<AddCardioRequest, AddCardioResponse>
{
    public async Task<AddCardioResponse> Handle(AddCardioRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Add(request.UserId, request.Model));
    }
}
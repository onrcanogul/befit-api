using BeFit.Application.DataTransferObjects.Friendship;
using BeFit.Application.Services.Friendship;

namespace BeFit.Application.Features.Friendship.Commands.Send;
public record SendFriendshipRequest(SendFriendshipDto Model) : IRequest<SendFriendshipResponse>;
public record SendFriendshipResponse(ServiceResponse<NoContent> Response);
public class SendFriendshipRequestHandler(IFriendshipService service) : IRequestHandler<SendFriendshipRequest, SendFriendshipResponse>
{
    public async Task<SendFriendshipResponse> Handle(SendFriendshipRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Send(request.Model));
    }
}
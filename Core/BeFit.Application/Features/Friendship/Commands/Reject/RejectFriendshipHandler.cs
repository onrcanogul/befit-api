using BeFit.Application.DataTransferObjects.Friendship;
using BeFit.Application.Services.Friendship;

namespace BeFit.Application.Features.Friendship.Commands.Accept;

public record RejectFriendshipRequest(string SenderId, string ReceiverId) : IRequest<RejectFriendshipResponse>;

public record RejectFriendshipResponse(ServiceResponse<NoContent> Response);

public class RejectFriendshipHandler(IFriendshipService service) : IRequestHandler<RejectFriendshipRequest, RejectFriendshipResponse>
{
    public async Task<RejectFriendshipResponse> Handle(RejectFriendshipRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Reject(request.SenderId, request.ReceiverId));
    }
}
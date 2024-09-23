using BeFit.Application.DataTransferObjects.Friendship;
using BeFit.Application.Services.Friendship;

namespace BeFit.Application.Features.Friendship.Queries.GetFromSender;

public record GetRejectedFriendshipFromReceiverRequest(string ReceiverId) : IRequest<GetRejectedFriendshipFromReceiverResponse>;
public record GetRejectedFriendshipFromReceiverResponse(ServiceResponse<List<FriendshipDto>> Response);
public class GetRejectedFriendshipFromReceiverHandler(IFriendshipService service) : IRequestHandler<GetRejectedFriendshipFromReceiverRequest, GetRejectedFriendshipFromReceiverResponse>
{
    public async Task<GetRejectedFriendshipFromReceiverResponse> Handle(GetRejectedFriendshipFromReceiverRequest request, CancellationToken cancellationToken)
    {
        return new(await service.GetRejectedRequestsFromReceiver(request.ReceiverId));
    }
}
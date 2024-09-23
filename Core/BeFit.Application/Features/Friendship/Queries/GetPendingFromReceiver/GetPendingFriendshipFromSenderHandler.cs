using BeFit.Application.DataTransferObjects.Friendship;
using BeFit.Application.Services.Friendship;

namespace BeFit.Application.Features.Friendship.Queries.GetFromSender;

public record GetPendingFriendshipFromReceiverRequest(string ReceiverId) : IRequest<GetPendingFriendshipFromReceiverResponse>;
public record GetPendingFriendshipFromReceiverResponse(ServiceResponse<List<FriendshipDto>> Response);
public class GetPendingFriendshipFromReceiverHandler(IFriendshipService service) : IRequestHandler<GetPendingFriendshipFromReceiverRequest, GetPendingFriendshipFromReceiverResponse>
{
    public async Task<GetPendingFriendshipFromReceiverResponse> Handle(GetPendingFriendshipFromReceiverRequest request, CancellationToken cancellationToken)
    {
        return new(await service.GetPendingRequestsFromReceiver(request.ReceiverId));
    }
}
using BeFit.Application.DataTransferObjects.Friendship;
using BeFit.Application.Services.Friendship;

namespace BeFit.Application.Features.Friendship.Queries.GetFromSender;

public record GetFriendshipFromReceiverRequset(string ReceiverId) : IRequest<GetFriendshipFromReceiverResponse>;
public record GetFriendshipFromReceiverResponse(ServiceResponse<List<FriendshipDto>> Response);
public class GetFriendshipFromReceiverHandler(IFriendshipService service) : IRequestHandler<GetFriendshipFromReceiverRequset, GetFriendshipFromReceiverResponse>
{
    public async Task<GetFriendshipFromReceiverResponse> Handle(GetFriendshipFromReceiverRequset request, CancellationToken cancellationToken)
    {
        return new(await service.GetFriendshipsFromReceiver(request.ReceiverId));
    }
}
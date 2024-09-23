using BeFit.Application.DataTransferObjects.Friendship;
using BeFit.Application.Services.Friendship;

namespace BeFit.Application.Features.Friendship.Queries.GetFromSender;

public record GetPendingFriendshipFromSenderRequest(string SenderId) : IRequest<GetPendingFriendshipFromSenderResponse>;
public record GetPendingFriendshipFromSenderResponse(ServiceResponse<List<FriendshipDto>> Response);
public class GetPendingFriendshipFromSenderHandler(IFriendshipService service) : IRequestHandler<GetPendingFriendshipFromSenderRequest, GetPendingFriendshipFromSenderResponse>
{
    public async Task<GetPendingFriendshipFromSenderResponse> Handle(GetPendingFriendshipFromSenderRequest request, CancellationToken cancellationToken)
    {
        return new(await service.GetPendingRequestsFromSender(request.SenderId));
    }
}
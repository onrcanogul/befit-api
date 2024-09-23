using BeFit.Application.DataTransferObjects.Friendship;
using BeFit.Application.Services.Friendship;

namespace BeFit.Application.Features.Friendship.Queries.GetFromSender;

public record GetRejectedFriendshipFromSenderRequest(string SenderId) : IRequest<GetRejectedFriendshipFromSenderResponse>;
public record GetRejectedFriendshipFromSenderResponse(ServiceResponse<List<FriendshipDto>> Response);
public class GetRejectedFriendshipFromSenderHandler(IFriendshipService service) : IRequestHandler<GetRejectedFriendshipFromSenderRequest, GetRejectedFriendshipFromSenderResponse>
{
    public async Task<GetRejectedFriendshipFromSenderResponse> Handle(GetRejectedFriendshipFromSenderRequest request, CancellationToken cancellationToken)
    {
        return new(await service.GetRejectedRequestsFromSender(request.SenderId));
    }
}
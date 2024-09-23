using BeFit.Application.DataTransferObjects.Friendship;
using BeFit.Application.Services.Friendship;

namespace BeFit.Application.Features.Friendship.Queries.GetFromSender;

public record GetFriendshipFromSenderRequset(string SenderId) : IRequest<GetFriendshipFromSenderResponse>;
public record GetFriendshipFromSenderResponse(ServiceResponse<List<FriendshipDto>> Response);
public class GetFriendshipFromSenderHandler(IFriendshipService service) : IRequestHandler<GetFriendshipFromSenderRequset, GetFriendshipFromSenderResponse>
{
    public async Task<GetFriendshipFromSenderResponse> Handle(GetFriendshipFromSenderRequset request, CancellationToken cancellationToken)
    {
        return new(await service.GetFriendshipsFromSender(request.SenderId));
    }
}
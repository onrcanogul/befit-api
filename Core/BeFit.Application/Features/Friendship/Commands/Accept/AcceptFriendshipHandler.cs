using BeFit.Application.DataTransferObjects.Friendship;
using BeFit.Application.Services.Friendship;

namespace BeFit.Application.Features.Friendship.Commands.Accept;

public record AcceptFriendshipRequest(string SenderId, string ReceiverId) : IRequest<AcceptFriendshipResponse>;

public record AcceptFriendshipResponse(ServiceResponse<NoContent> Response);

public class AcceptFriendshipHandler(IFriendshipService service) : IRequestHandler<AcceptFriendshipRequest, AcceptFriendshipResponse>
{
    public async Task<AcceptFriendshipResponse> Handle(AcceptFriendshipRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Accept(request.SenderId, request.ReceiverId));
    }
}
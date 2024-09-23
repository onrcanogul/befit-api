using System.Data.Entity.Core.Objects;
using BeFit.Application.DataTransferObjects.Friendship;

namespace BeFit.Application.Services.Friendship;

public interface IFriendshipService
{
    Task<ServiceResponse<NoContent>> Send(FriendshipDto friendship);
    Task<ServiceResponse<NoContent>> Accept(string senderId, string receiverId);
    Task<ServiceResponse<NoContent>> Reject(string senderId, string receiverId);
    Task<ServiceResponse<List<FriendshipDto>>> GetFriendshipsFromSender(string senderId);
    Task<ServiceResponse<List<FriendshipDto>>> GetFriendshipsFromReceiver(string receiverId);
    Task<ServiceResponse<List<FriendshipDto>>> GetRejectedRequestsFromReceiver(string receiverId);
    Task<ServiceResponse<List<FriendshipDto>>> GetRejectedRequestsFromSender(string senderId);
    Task<ServiceResponse<List<FriendshipDto>>> GetPendingRequestsFromReceiver(string receiverId);
    Task<ServiceResponse<List<FriendshipDto>>> GetPendingRequestsFromSender(string senderId);
}
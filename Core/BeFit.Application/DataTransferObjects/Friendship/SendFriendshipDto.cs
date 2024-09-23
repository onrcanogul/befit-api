using BeFit.Domain.Entities.Enums;

namespace BeFit.Application.DataTransferObjects.Friendship;

public class SendFriendshipDto
{
    public string SenderId { get; set; } = null!;
    public string ReceiverId { get; set; } = null!;

    public FriendshipStatus Status = FriendshipStatus.Pending;
}
using BeFit.Domain.Entities.Enums;
using BeFit.Domain.Entities.Identity;

namespace BeFit.Application.DataTransferObjects.Friendship
{
    public class FriendshipDto : BaseDto
    {
        public string SenderId { get; set; } = null!;
        public string ReceiverId { get; set; } = null!;
        public FriendshipStatus FriendshipStatus { get; set; } = FriendshipStatus.Pending;
        public User Sender { get; set; } = null!;
        public User Receiver { get; set; } = null!;
    }
}

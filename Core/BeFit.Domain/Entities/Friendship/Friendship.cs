using BeFit.Domain.Entities.Base;
using BeFit.Domain.Entities.Enums;
using BeFit.Domain.Entities.Identity;

namespace BeFit.Domain.Entities
{
    public class Friendship : BaseEntity
    {
        public string SenderId { get; set; } = null!;
        public string ReceiverId { get; set; } = null!;
        public User Sender { get; set; } = null!;
        public User Receiver { get; set; } = null!;
        public FriendshipStatus Status { get; set; }
    }
}

using System.Text.Json.Serialization;
using BeFit.Domain.Entities.Enums;
using BeFit.Domain.Entities.Identity;

namespace BeFit.Application.DataTransferObjects.Friendship
{
    public class FriendshipDto : BaseDto
    {
        [JsonIgnore]
        public string SenderId { get; set; } = null!;
        [JsonIgnore]
        public string ReceiverId { get; set; } = null!;
        public FriendshipStatus FriendshipStatus { get; set; } = FriendshipStatus.Pending;
        public UserDto Sender { get; set; } = null!;
        public UserDto Receiver { get; set; } = null!;
    }
}

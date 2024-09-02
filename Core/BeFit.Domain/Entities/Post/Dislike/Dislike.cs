using BeFit.Domain.Entities.Base;
using BeFit.Domain.Entities.Identity;

namespace BeFit.Domain.Entities
{
    public abstract class Dislike : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}

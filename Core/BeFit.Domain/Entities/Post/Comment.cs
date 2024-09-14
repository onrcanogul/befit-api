using BeFit.Domain.Entities.Base;
using BeFit.Domain.Entities.Identity;

namespace BeFit.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        public User User { get; set; } = null!;
        public List<CommentDislike> Dislikes { get; set; } = new();
        public List<CommentLike> Likes { get; set; } = new();
    }
}
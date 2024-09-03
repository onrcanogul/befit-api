using BeFit.Domain.Entities.Base;
using BeFit.Domain.Entities.Identity;

namespace BeFit.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public List<PostImage> Images { get; set; } = new();
        public List<PostDislike> Dislikes { get; set; } = new();
        public List<PostLike> Likes { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();
    }
}

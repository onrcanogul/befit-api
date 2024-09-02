using BeFit.Domain.Entities.Base;
using BeFit.Domain.Entities.Identity;

namespace BeFit.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; } = null!;    
        public string PostId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public Post Post { get; set; } = null!;
        public User User { get; set; } = null!;
        public List<CommentDislike> Dislikes { get; set; } = new();
        public List<CommentLike> Likes { get; set; } = new();

        //nested comment
        public Guid? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
        public List<Comment> Replies { get; set; } = new();
    }

}

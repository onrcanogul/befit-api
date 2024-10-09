using Microsoft.AspNetCore.Identity;

namespace BeFit.Domain.Entities.Identity
{
    public class User : IdentityUser<string>
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public UserProperties Properties { get; set; }
        public List<Post> Posts { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();
        public List<CommentLike> CommentLikes { get; set; } = new();
        public List<CommentDislike> CommentDislikes { get; set; } = new();
        public List<PostLike> PostLikes { get; set; } = new();
        public List<PostDislike> PostDislikes { get; set; } = new();
        public List<Training> Trainings { get; set; } = new();
        public List<Cardio> Cardios { get; set; } = new();

    }
}

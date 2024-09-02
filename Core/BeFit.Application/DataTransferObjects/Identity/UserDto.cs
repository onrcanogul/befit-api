using BeFit.Domain.Entities;

namespace BeFit.Application.DataTransferObjects
{
    public class UserDto
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Gender Gender { get; set; }
        public List<PostDto> Posts { get; set; } = new();
        public List<CommentDto> Comments { get; set; } = new();
        public List<CommentLikeDto> CommentLikes { get; set; } = new();
        public List<PostLikeDto> PostLikes { get; set; } = new();
        public List<PostDislikeDto> PostDislikes { get; set; } = new();
        public List<CommentDislikeDto> CommentDislikes { get; set; } = new();
    }
}

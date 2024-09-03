using BeFit.Domain.Entities;

namespace BeFit.Application.DataTransferObjects
{
    public class PostDto : BaseDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public UserDto User { get; set; } = null!;
        public List<PostImageDto> Images { get; set; } = new();
        public List<PostDislikeDto> Dislikes { get; set; } = new();
        public List<PostLikeDto> Likes { get; set; } = new();
        public List<CommentDto> Comments { get; set; } = new();
    }
}

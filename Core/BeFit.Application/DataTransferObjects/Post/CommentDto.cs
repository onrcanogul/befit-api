namespace BeFit.Application.DataTransferObjects
{
    public class CommentDto : BaseDto
    {
        public string Text { get; set; } = null!;
        public string PostId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public PostDto Post { get; set; } = null!;
        public UserDto User { get; set; } = null!;
        public List<CommentDislikeDto> Dislikes { get; set; } = new();
        public List<CommentLikeDto> Likes { get; set; } = new();

        //nested comment
        public Guid? ParentCommentId { get; set; }
        public CommentDto? ParentComment { get; set; }
        public List<CommentDto> Replies { get; set; } = new();
    }
}

namespace BeFit.Application.DataTransferObjects
{
    public class CommentDislikeDto : DislikeDto
    {
        public Guid CommentId { get; set; }
        public CommentDto Comment { get; set; } = null!;
    }
}

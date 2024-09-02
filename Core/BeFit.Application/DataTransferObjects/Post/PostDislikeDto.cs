namespace BeFit.Application.DataTransferObjects
{
    public class PostDislikeDto : DislikeDto
    {
        public Guid PostId { get; set; }
        public PostDto Post { get; set; } = null!;
    }
}

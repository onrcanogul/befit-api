namespace BeFit.Application.DataTransferObjects
{
    public class PostImageDto : ImageDto
    {
        public Guid PostId { get; set; }
        public PostDto Post { get; set; } = null!;
    }
}

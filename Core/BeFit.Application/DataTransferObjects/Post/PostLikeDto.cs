namespace BeFit.Application.DataTransferObjects
{
    public class PostLikeDto : LikeDto
    {
        public Guid PostId { get; set; }
        public PostDto Post { get; set; } = null!;
    }
}

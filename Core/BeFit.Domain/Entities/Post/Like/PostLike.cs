namespace BeFit.Domain.Entities
{
    public class PostLike : Like
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; } = null!;
    }
}

namespace BeFit.Domain.Entities
{
    public class PostImage : Image
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; } = null!;
    }
}

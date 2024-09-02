namespace BeFit.Domain.Entities
{
    public class PostDislike : Dislike
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; } = null!;
    }
}

namespace BeFit.Domain.Entities
{
    public class CommentDislike : Dislike
    {
        public Guid CommentId { get; set; }
        public Comment Comment { get; set; } = null!;
    }
}

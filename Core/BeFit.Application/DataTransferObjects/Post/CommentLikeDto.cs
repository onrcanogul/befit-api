using BeFit.Domain.Entities;

namespace BeFit.Application.DataTransferObjects
{
    public class CommentLikeDto : LikeDto
    {
        public Guid CommentId { get; set; }
        public CommentDto Comment { get; set; } = null!;
    }
}

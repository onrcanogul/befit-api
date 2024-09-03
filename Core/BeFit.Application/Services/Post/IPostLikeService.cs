using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;

namespace BeFit.Application.Services.Post
{
    public interface IPostLikeService
    {
        Task<ServiceResponse<List<PostLikeDto>>> GetByPost(Guid postId);
        Task<ServiceResponse<NoContent>> Like(Guid postId, string userId);
    }
}

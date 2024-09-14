namespace BeFit.Application.Services.Post
{
    public interface IPostDislikeService
    {
        Task<ServiceResponse<List<PostDislikeDto>>> GetByPost(Guid postId);
        Task<ServiceResponse<NoContent>> Dislike(Guid postId, string userId);
    }
}

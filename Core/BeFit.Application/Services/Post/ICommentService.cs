namespace BeFit.Application.Services.Post
{
    public interface ICommentService
    {
        Task<ServiceResponse<List<CommentDto>>> GetByPost(Guid postId);
        Task<ServiceResponse<NoContent>> Create(string text, string userId);
        Task<ServiceResponse<NoContent>> Update(string text, Guid Id);
        Task<ServiceResponse<NoContent>> Delete(Guid id);
    }
}

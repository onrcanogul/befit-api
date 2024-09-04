using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.Comment.Queries.GetByPost
{
    public record GetCommentByPostRequest(Guid PostId) : IRequest<GetCommentByPostResponse>;

    public record GetCommentByPostResponse(ServiceResponse<List<CommentDto>> Response);
    public class GetCommentByPostHandler(ICommentService service) : IRequestHandler<GetCommentByPostRequest, GetCommentByPostResponse>
    {
        public async Task<GetCommentByPostResponse> Handle(GetCommentByPostRequest request, CancellationToken cancellationToken)
        {
            return new(await service.GetByPost(request.PostId));
        }
    }
}

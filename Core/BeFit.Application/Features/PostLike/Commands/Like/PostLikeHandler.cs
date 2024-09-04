using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.PostLike.Commands
{
    public record PostLikeRequest(Guid PostId, string UserId) : IRequest<PostLikeResponse>;
    public record PostLikeResponse(ServiceResponse<NoContent> Response);
    public class PostLikeHandler(IPostLikeService service) : IRequestHandler<PostLikeRequest, PostLikeResponse>
    {
        public async Task<PostLikeResponse> Handle(PostLikeRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Like(request.PostId, request.UserId));
        }
    }
}

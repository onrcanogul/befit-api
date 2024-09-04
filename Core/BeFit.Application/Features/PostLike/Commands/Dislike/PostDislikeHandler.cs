using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.PostLike.Commands.Dislike
{
    public record PostDislikeRequest(Guid PostId, string UserId) : IRequest<PostDislikeResponse>;
    public record PostDislikeResponse(ServiceResponse<NoContent> Response);
    public class PostDislikeHandler(IPostDislikeService service) : IRequestHandler<PostDislikeRequest, PostDislikeResponse>
    {
        public async Task<PostDislikeResponse> Handle(PostDislikeRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Dislike(request.PostId, request.UserId));
        }
    }
}

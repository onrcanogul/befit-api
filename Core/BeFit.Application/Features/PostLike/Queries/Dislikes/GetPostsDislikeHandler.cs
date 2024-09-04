using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.PostLike.Queries.Dislikes
{
    public record GetPostsDislikeRequest(Guid PostId) : IRequest<GetPostsDislikeResponse>;
    public record GetPostsDislikeResponse(ServiceResponse<List<PostDislikeDto>> Response);
    public class GetPostsDislikeHandler(IPostDislikeService service) : IRequestHandler<GetPostsDislikeRequest, GetPostsDislikeResponse>
    {
        public async Task<GetPostsDislikeResponse> Handle(GetPostsDislikeRequest request, CancellationToken cancellationToken)
        {
            return new(await service.GetByPost(request.PostId));
        }
    }
}
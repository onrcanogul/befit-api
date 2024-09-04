using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.PostLike.Queries.Likes
{
    public record GetPostsLikeRequest(Guid PostId) : IRequest<GetPostsLikeResponse>;
    public record GetPostsLikeResponse(ServiceResponse<List<PostLikeDto>> Response);
    public class GetPostsLikeHandler(IPostLikeService service) : IRequestHandler<GetPostsLikeRequest, GetPostsLikeResponse>
    {
        public async Task<GetPostsLikeResponse> Handle(GetPostsLikeRequest request, CancellationToken cancellationToken)
        {
            return new(await service.GetByPost(request.PostId));
        }
    }
}

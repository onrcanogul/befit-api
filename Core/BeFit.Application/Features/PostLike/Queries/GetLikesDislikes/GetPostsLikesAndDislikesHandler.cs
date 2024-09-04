using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.PostLike.Queries.GetLikesDislikes
{
    public record GetPostsLikesAndDislikesRequest(Guid PostId) : IRequest<GetPostsLikesAndDislikesResponse>;
    public record GetPostsLikesAndDislikesResponse(List<PostLikeDto> Likes, List<PostDislikeDto> Dislikes);
    public class GetPostsLikesAndDislikesHandler(IPostDislikeService dService, IPostLikeService lService) : IRequestHandler<GetPostsLikesAndDislikesRequest, GetPostsLikesAndDislikesResponse>
    {
        public async Task<GetPostsLikesAndDislikesResponse> Handle(GetPostsLikesAndDislikesRequest request, CancellationToken cancellationToken)
        {
            var likes = await lService.GetByPost(request.PostId);
            var dislikes = await dService.GetByPost(request.PostId);

            return new(likes.Data, dislikes.Data);
        }
    }
}

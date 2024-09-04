using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.Post.Queries.Get
{
    public record GetPostsRequest(int Page, int Size) : IRequest<GetPostsResponse>;
    public record GetPostsResponse(ServiceResponse<List<PostDto>> Posts);
    public class GetPostsHandler(IPostService service) : IRequestHandler<GetPostsRequest, GetPostsResponse>
    {
        public async Task<GetPostsResponse> Handle(GetPostsRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Get(request.Page, request.Size));
        }
    }
}

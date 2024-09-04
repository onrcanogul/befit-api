using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.Post.Queries.GetByUser
{
    public record GetPostByUserRequest(string UserId) : IRequest<GetPostByUserResponse>;
    public record GetPostByUserResponse(ServiceResponse<List<PostDto>> Posts);
    public class GetPostByUserHandler(IPostService service) : IRequestHandler<GetPostByUserRequest, GetPostByUserResponse>
    {
        public async Task<GetPostByUserResponse> Handle(GetPostByUserRequest request, CancellationToken cancellationToken)
        {
            return new(await service.GetByUser(request.UserId));
        }
    }
}

using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.Post.Queries.GetById
{
    public record GetPostByIdRequest(Guid Id) : IRequest<GetPostByIdResponse>;

    public record GetPostByIdResponse(ServiceResponse<PostDto> Response);
    public class GetPostByIdHandler(IPostService service) : IRequestHandler<GetPostByIdRequest, GetPostByIdResponse>
    {
        public async Task<GetPostByIdResponse> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
        {
            return new(await service.GetById(request.Id));
        }
    }
}

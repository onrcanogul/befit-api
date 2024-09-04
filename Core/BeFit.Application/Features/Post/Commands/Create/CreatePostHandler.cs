using BeFit.Application.DataTransferObjects.Post.CreateDtos;
using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.Post.Commands.Create
{
    public record CreatePostRequest(CreatePostDto Model) : IRequest<CreatePostResponse>;
    public record CreatePostResponse(ServiceResponse<NoContent> Response);
    public class CreatePostHandler(IPostService service) : IRequestHandler<CreatePostRequest, CreatePostResponse>
    {
        public async Task<CreatePostResponse> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Create(request.Model));
        }
    }
}

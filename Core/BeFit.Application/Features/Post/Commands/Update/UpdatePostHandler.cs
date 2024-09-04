using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.Post.Commands.Update
{
    public record UpdatePostRequest(UpdatePostDto Model) : IRequest<UpdatePostResponse>;

    public record UpdatePostResponse(ServiceResponse<NoContent> Response);
    public class UpdatePostHandler(IPostService service) : IRequestHandler<UpdatePostRequest, UpdatePostResponse>
    {
        public async Task<UpdatePostResponse> Handle(UpdatePostRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Update(request.Model));
        }
    }
}

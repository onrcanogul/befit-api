using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.Comment.Commands.Create
{
    public record CreateCommentRequest(string Text, string UserId) : IRequest<CreateCommentResponse>;
    public record CreateCommentResponse(ServiceResponse<NoContent> Response);
    public class CreateCommentHandler(ICommentService service) : IRequestHandler<CreateCommentRequest, CreateCommentResponse>
    {
        public async Task<CreateCommentResponse> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Create(request.Text, request.UserId));
        }
    }
}

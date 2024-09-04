using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.Comment.Commands.Delete
{
    public record DeleteCommentRequest(Guid Id) : IRequest<DeleteCommentResponse>;
    public record DeleteCommentResponse(ServiceResponse<NoContent> Response);
    public class DeleteCommentHandler(ICommentService service) : IRequestHandler<DeleteCommentRequest, DeleteCommentResponse>
    {
        public async Task<DeleteCommentResponse> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Delete(request.Id));
        }
    }
}

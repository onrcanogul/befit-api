using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.Comment.Commands.Update
{
    public record UpdateCommentRequest(string Text, Guid Id) : IRequest<UpdateCommentResponse>;
    public record UpdateCommentResponse(ServiceResponse<NoContent> Response);
    public class UpdateCommentHandler(ICommentService service) : IRequestHandler<UpdateCommentRequest, UpdateCommentResponse>
    {
        public async Task<UpdateCommentResponse> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Update(request.Text, request.Id));
        }
    }
}

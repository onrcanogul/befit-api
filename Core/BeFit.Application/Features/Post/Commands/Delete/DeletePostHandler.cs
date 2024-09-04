using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeFit.Application.Services.Post;

namespace BeFit.Application.Features.Post.Commands.Delete
{
    public record DeletePostRequest(Guid Id) : IRequest<DeletePostResponse>;
    public record DeletePostResponse(ServiceResponse<NoContent> Response);
    public class DeletePostHandler(IPostService service) : IRequestHandler<DeletePostRequest, DeletePostResponse>
    {
        public async Task<DeletePostResponse> Handle(DeletePostRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Delete(request.Id));
        }
    }
}

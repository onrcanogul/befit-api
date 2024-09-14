using BeFit.API.Controllers.Base;
using BeFit.Application.Features.Comment.Commands.Create;
using BeFit.Application.Features.Comment.Commands.Delete;
using BeFit.Application.Features.Comment.Commands.Update;
using BeFit.Application.Features.Comment.Queries.GetByPost;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController(IMediator mediator) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetByPost(GetCommentByPostRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCommentRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCommentRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);
    }
}
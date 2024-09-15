using BeFit.API.Controllers.Base;
using BeFit.Application.Features.User.Queries.Get;
using BeFit.Application.Features.User.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => ControllerResponse((await mediator.Send(new GetUserRequest())).Response);

        [HttpGet("id")]
        public async Task<IActionResult> Get([FromQuery]GetUserByIdRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);
    }
}

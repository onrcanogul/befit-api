using BeFit.API.Controllers.Base;
using BeFit.Application.Features.User.Commands;
using BeFit.Application.Features.User.Queries.Get;
using BeFit.Application.Features.User.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers;
    public class UserController(IMediator mediator) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => ControllerResponse((await mediator.Send(new GetUserRequest()).ConfigureAwait(false)).Response);

        [HttpGet("id")]
        public async Task<IActionResult> Get([FromQuery]GetUserByIdRequest request)
            => ControllerResponse((await mediator.Send(request).ConfigureAwait(false)).Response);

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateUserRequest request)
            => ControllerResponse((await mediator.Send(request).ConfigureAwait(false)).Response);
    }


using BeFit.API.Controllers.Base;
using BeFit.Application.Features.UserProperties.Commands.Create;
using BeFit.Application.Features.UserProperties.Commands.Update;
using BeFit.Application.Features.UserProperties.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers;
    public class UserPropertiesController(IMediator mediator) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetUserPropertiesRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserPropertiesRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserPropertyRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);
    }

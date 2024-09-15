using BeFit.API.Controllers.Base;
using BeFit.Application.Features.UserProperties.Commands.Create;
using BeFit.Application.Features.UserProperties.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPropertiesController(IMediator mediator) : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserPropertiesRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserPropertyRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);
    }
}
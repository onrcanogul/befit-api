using BeFit.API.Controllers.Base;
using BeFit.Application.Features.Cardio.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers;

public class CardioController(IMediator mediator) : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(AddCardioRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpPut]
    public async Task<IActionResult> Add(UpdateCardioRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpDelete]
    public async Task<IActionResult> Add(DeleteCardioRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);

}
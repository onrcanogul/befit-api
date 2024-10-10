using BeFit.API.Controllers.Base;
using BeFit.Application.Features.Basket.Command.Clear;
using BeFit.Application.Features.Basket.Query.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers;

public class BasketController(IMediator mediator) : CustomBaseController
{
    [HttpGet("{UserId}")]
    public async Task<IActionResult> Get([FromRoute]GetBasketRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpPost]
    public async Task<IActionResult> Clear(ClearBasketRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
}
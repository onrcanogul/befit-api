using BeFit.API.Controllers.Base;
using BeFit.Application.Features.BasketItem.Command;
using BeFit.Application.Features.BasketItem.Command.Delete;
using BeFit.Application.Features.BasketItem.Command.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers;

public class BasketItemController(IMediator mediator) : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(AddBasketItemRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpPut]
    public async Task<IActionResult> Update(UpdateBasketItemRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
        => ControllerResponse((await mediator.Send(new DeleteBasketItemRequest(id))).Response);
}    

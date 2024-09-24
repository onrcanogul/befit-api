using BeFit.API.Controllers.Base;
using BeFit.Application.Features.Food.Command.Create;
using BeFit.Application.Features.Food.Command.Delete;
using BeFit.Application.Features.Food.Command.Update;
using BeFit.Application.Features.Food.Query.Get;
using BeFit.Application.Features.Food.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace BeFit.API.Controllers;
public class FoodController(IMediator mediator) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]GetFoodsRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute]GetFoodByIdRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpPost]
    public async Task<IActionResult> Create(CreateFoodRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFoodRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute]DeleteFoodRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
}
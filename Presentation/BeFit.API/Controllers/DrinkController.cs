using BeFit.API.Controllers.Base;
using BeFit.Application.Features.Drink.Command.Create;
using BeFit.Application.Features.Drink.Command.Delete;
using BeFit.Application.Features.Drink.Command.Update;
using BeFit.Application.Features.Drink.Query.Get;
using BeFit.Application.Features.Drink.Query.GetById;
using BeFit.Application.Features.Food.Query.Filter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace BeFit.API.Controllers;

public class DrinkController(IMediator mediator) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]GetDrinksRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpGet("filter")]
    public async Task<IActionResult> GetFilter([FromBody]FilterDrinkRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute]GetDrinkByIdRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpPost]
    public async Task<IActionResult> Create(CreateDrinkRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpPut]
    public async Task<IActionResult> Update([FromBody]UpdateDrinkRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute]DeleteDrinkRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
}
using BeFit.API.Controllers.Base;
using BeFit.Application.Features.Exercise.Command.Create;
using BeFit.Application.Features.Exercise.Command.Delete;
using BeFit.Application.Features.Exercise.Query.Get;
using BeFit.Application.Features.Exercise.Query.GetId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers;

public class ExerciseController(IMediator mediator) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]GetExerciseRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute]GetExerciseByIdRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpPost]
    public async Task<IActionResult> Create(CreateExerciseRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpPut]
    public async Task<IActionResult> Update(UpdateExerciseRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteExerciseRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
}
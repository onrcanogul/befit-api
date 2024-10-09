using BeFit.API.Controllers.Base;
using BeFit.Application.Features.Cardio.Command;
using BeFit.Application.Features.Cardio.Training;
using BeFit.Application.Features.Training;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers;

public class TrainingController(IMediator mediator) : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(AddTrainingRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpPut]
    public async Task<IActionResult> Add(UpdateTrainingRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpDelete]
    public async Task<IActionResult> Add(DeleteTrainingRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
}
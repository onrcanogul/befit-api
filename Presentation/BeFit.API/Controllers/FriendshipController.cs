using BeFit.API.Controllers.Base;
using BeFit.Application.Features.Friendship.Commands.Accept;
using BeFit.Application.Features.Friendship.Commands.Send;
using BeFit.Application.Features.Friendship.Queries.GetFromSender;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers;
public class FriendshipController(IMediator mediator) : CustomBaseController
{
    [HttpPost("send")]
    public async Task<IActionResult> Send(SendFriendshipRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpPost("accept")]
    public async Task<IActionResult> Accept(AcceptFriendshipRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpPost("reject")]
    public async Task<IActionResult> Send(RejectFriendshipRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpGet("getBySender")]
    public async Task<IActionResult> Send([FromQuery]GetFriendshipFromSenderRequset request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpGet("getByReceiver")]
    public async Task<IActionResult> Send([FromQuery]GetFriendshipFromReceiverRequset request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpGet("getPendingByReceiver")]
    public async Task<IActionResult> Send([FromQuery]GetPendingFriendshipFromReceiverRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpGet("getPendingBySender")]
    public async Task<IActionResult> Send([FromQuery]GetPendingFriendshipFromSenderRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpGet("getRejectedByReceiver")]
    public async Task<IActionResult> Send([FromQuery]GetRejectedFriendshipFromReceiverRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    [HttpGet("getRejectedBySender")]
    public async Task<IActionResult> Send([FromQuery]GetRejectedFriendshipFromSenderRequest request)
        => ControllerResponse((await mediator.Send(request)).Response);
    
}
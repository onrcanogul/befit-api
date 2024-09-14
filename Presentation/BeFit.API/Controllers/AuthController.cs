﻿using BeFit.API.Controllers.Base;
using BeFit.Application.Features.Auth.Commands.Login;
using BeFit.Application.Features.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : CustomBaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);
    }
}
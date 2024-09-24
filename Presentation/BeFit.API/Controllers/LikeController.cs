using BeFit.API.Controllers.Base;
using BeFit.Application.Features.PostLike.Commands;
using BeFit.Application.Features.PostLike.Commands.Dislike;
using BeFit.Application.Features.PostLike.Queries.Dislikes;
using BeFit.Application.Features.PostLike.Queries.Likes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers;
    public class LikeController(IMediator mediator) : CustomBaseController
    {
        [HttpGet("post-likes")]
        public async Task<IActionResult> GetPostLikes([FromQuery]GetPostsLikeRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);

        [HttpGet("post-dislikes")]
        public async Task<IActionResult> GetPostDislikes([FromQuery]GetPostsDislikeRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);

        [HttpPost("like-post")]
        public async Task<IActionResult> LikePost(PostLikeRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);

        [HttpPost("dislike-post")]
        public async Task<IActionResult> DislikePost(PostDislikeRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);
    }

using BeFit.API.Controllers.Base;
using BeFit.Application.Features.Category.Commands.Create;
using BeFit.Application.Features.Category.Commands.Delete;
using BeFit.Application.Features.Category.Commands.Update;
using BeFit.Application.Features.Category.Queries.Get;
using BeFit.Application.Features.Category.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeFit.API.Controllers;
    public class CategoryController(IMediator mediator) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => ControllerResponse((await mediator.Send(new GetCategoriesRequest())).Categories);


        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery]GetCategoryByIdRequest request)
            => ControllerResponse((await mediator.Send(request)).Category);


        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);


        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);


        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCategoryRequest request)
            => ControllerResponse((await mediator.Send(request)).Response);
    }

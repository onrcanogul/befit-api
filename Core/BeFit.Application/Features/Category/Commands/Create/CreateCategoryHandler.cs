﻿using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.Services.Category;
using MediatR;

namespace BeFit.Application.Features.Category.Commands.Create
{
    public record CreateCategoryRequest(CategoryDto Model) : IRequest<CreateCategoryResponse>;
    public record CreateCategoryResponse(ServiceResponse<NoContent> Response);
    public class CreateCategoryHandler(ICategoryService service) : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
    {
        public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Create(request.Model));
        }
    }
}

﻿using BeFit.Application.DataTransferObjects.Update;

namespace BeFit.Application.Features.Category.Commands.Update
{
    public record UpdateCategoryRequest(UpdateCategoryDto Model) : IRequest<UpdateCategoryResponse>;

    public record UpdateCategoryResponse(ServiceResponse<NoContent> Response);

    public class UpdateCategoryHandler(ICategoryService service)
        : IRequestHandler<UpdateCategoryRequest, UpdateCategoryResponse>
    {
        public async Task<UpdateCategoryResponse> Handle(UpdateCategoryRequest request,
            CancellationToken cancellationToken)
        {
            return new(await service.Update(request.Model));
        }
    }
}


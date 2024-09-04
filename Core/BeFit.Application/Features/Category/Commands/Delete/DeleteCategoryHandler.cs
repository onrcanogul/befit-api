namespace BeFit.Application.Features.Category.Commands.Delete
{
    public record DeleteCategoryRequest(Guid Id) : IRequest<DeleteCategoryResponse>;

    public record DeleteCategoryResponse(ServiceResponse<NoContent> Response);
    public class DeleteCategoryHandler(ICategoryService service) : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
    {
        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Delete(request.Id));
        }
    }
}

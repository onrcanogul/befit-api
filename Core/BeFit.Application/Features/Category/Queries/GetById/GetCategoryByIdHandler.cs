namespace BeFit.Application.Features.Category.Queries.GetById
{
    public record GetCategoryByIdRequest(Guid Id) : IRequest<GetCategoryByIdResponse>;
    public record GetCategoryByIdResponse(ServiceResponse<CategoryDto> category);

    public class GetCategoryByIdHandler(ICategoryService service) : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
    {
        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            return new(await service.GetById(request.Id));
        }
    }
}

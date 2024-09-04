namespace BeFit.Application.Features.Category.Queries.Get
{
    public record GetCategoriesRequest() : IRequest<GetCategoriesResponse>;
    public record GetCategoriesResponse(ServiceResponse<List<CategoryDto>> Categories);

    public class GetCategoriesHandler(ICategoryService service) : IRequestHandler<GetCategoriesRequest, GetCategoriesResponse>
    {
        public async Task<GetCategoriesResponse> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Get());
        }
    }
}

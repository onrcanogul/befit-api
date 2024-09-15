using BeFit.Application.Services.Identity;

namespace BeFit.Application.Features.UserProperties.Commands.Create
{
    public record CreateUserPropertiesRequest(UserPropertiesDto Model) : IRequest<CreateUserPropertiesResponse>;

    public record CreateUserPropertiesResponse(ServiceResponse<NoContent> Response);
    public class CreateUserPropertiesHandler(IUserPropertyService service) : IRequestHandler<CreateUserPropertiesRequest, CreateUserPropertiesResponse>
    {
        public async Task<CreateUserPropertiesResponse> Handle(CreateUserPropertiesRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Create(request.Model));
        }
    }
}

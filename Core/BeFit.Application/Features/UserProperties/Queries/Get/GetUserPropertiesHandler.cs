using BeFit.Application.Services.Identity;

namespace BeFit.Application.Features.UserProperties.Queries.Get;

public record GetUserPropertiesRequest(string UserId) : IRequest<GetUserPropertiesResponse>;

public record GetUserPropertiesResponse(ServiceResponse<UserPropertiesDto> Response);

public class GetUserPropertiesHandler(IUserPropertyService service) : IRequestHandler<GetUserPropertiesRequest, GetUserPropertiesResponse>
{
    public async Task<GetUserPropertiesResponse> Handle(GetUserPropertiesRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Get(request.UserId));
    }
}
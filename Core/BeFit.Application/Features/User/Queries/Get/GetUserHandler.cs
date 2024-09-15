using BeFit.Application.Services;

namespace BeFit.Application.Features.User.Queries.Get
{
    public record GetUserRequest() : IRequest<GetUserResponse>;
    public record GetUserResponse(ServiceResponse<List<UserDto>> Response);
    public class GetUserHandler(IUserService service) : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Get());
        }
    }
}
using BeFit.Application.Services.Identity;

namespace BeFit.Application.Features.Auth.Commands.Login
{
    public record LoginRequest(LoginDto Model) : IRequest<LoginResponse>;
    public record LoginResponse(ServiceResponse<Token> Response); //token will be added 
    public class LoginHandler(IAuthService service) : IRequestHandler<LoginRequest, LoginResponse>
    {
        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Login(request.Model));
        }
    }
}

using BeFit.Application.Services.Identity;

namespace BeFit.Application.Features.Auth.Commands.RefreshTokenLogin;

public record RefreshTokenLoginRequest(string RefreshToken) : IRequest<RefreshTokenLoginResponse>;

public record RefreshTokenLoginResponse(ServiceResponse<Token> Response);

public class RefreshTokenLoginHandler(IAuthService service) : IRequestHandler<RefreshTokenLoginRequest, RefreshTokenLoginResponse>
{
    public async Task<RefreshTokenLoginResponse> Handle(RefreshTokenLoginRequest request, CancellationToken cancellationToken)
    { 
        return new(await service.LoginWithRefreshToken(request.RefreshToken));
    }
}
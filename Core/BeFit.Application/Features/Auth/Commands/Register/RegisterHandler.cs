using BeFit.Application.Services.Identity;

namespace BeFit.Application.Features.Auth.Commands.Register
{
    public record RegisterRequest(RegisterDto Model) : IRequest<RegisterResponse>;
    public record RegisterResponse(ServiceResponse<NoContent> Response);  
    public class RegisterHandler(IAuthService service) : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Register(request.Model));
        }
    }
}

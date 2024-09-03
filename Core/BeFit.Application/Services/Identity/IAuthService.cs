using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;

namespace BeFit.Application.Services.Identity
{
    public interface IAuthService
    {
        Task<ServiceResponse<NoContent>> Register(RegisterDto model);
        Task<ServiceResponse<NoContent>> Login(LoginDto model); //token
    }
}

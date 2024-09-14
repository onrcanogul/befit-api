using BeFit.Domain.Entities.Identity;

namespace BeFit.Application.Services.Identity
{
    public interface IAuthService
    {
        Task<ServiceResponse<NoContent>> Register(RegisterDto model);
        Task<ServiceResponse<DataTransferObjects.Token>> Login(LoginDto model); //token
        Task<ServiceResponse<DataTransferObjects.Token>> LoginWithRefreshToken(string refreshToken);
        Task UpdateRefreshTokenAsync(string refreshToken, User user, DateTime accessTokenDate, int addToAccessToken);

    }
}

using BeFit.Domain.Entities.Identity;

namespace BeFit.Application.Services.Token
{
    public interface ITokenHandler
    {
        DataTransferObjects.Token CreateToken(User user);
    }
}

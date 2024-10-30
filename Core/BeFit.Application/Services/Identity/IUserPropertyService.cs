using BeFit.Application.DataTransferObjects.Create;
using BeFit.Application.DataTransferObjects.Update;

namespace BeFit.Application.Services.Identity
{
    public interface IUserPropertyService
    {
        Task<ServiceResponse<NoContent>> Create(CreateUserPropertiesDto model);
        Task<ServiceResponse<NoContent>> Update(UpdateUserPropertiesDto model);
        Task<ServiceResponse<UserPropertiesDto>> Get(string userId);
    }
}

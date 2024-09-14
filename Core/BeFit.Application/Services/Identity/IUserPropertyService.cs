namespace BeFit.Application.Services.Identity
{
    public interface IUserPropertyService
    {
        Task<ServiceResponse<NoContent>> CreateUserProperties(UserPropertiesDto model);
    }
}

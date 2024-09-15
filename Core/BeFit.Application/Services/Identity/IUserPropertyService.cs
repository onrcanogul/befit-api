namespace BeFit.Application.Services.Identity
{
    public interface IUserPropertyService
    {
        Task<ServiceResponse<NoContent>> Create(UserPropertiesDto model);
        Task<ServiceResponse<NoContent>> Update(UserPropertiesDto model);
    }
}

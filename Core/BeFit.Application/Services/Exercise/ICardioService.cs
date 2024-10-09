namespace BeFit.Application.Services.Exercise;

public interface ICardioService
{
    Task<ServiceResponse<NoContent>> Add(string userId, CardioDto model);
    Task<ServiceResponse<NoContent>> Update(string userId, Guid exerciseId, decimal minutes);
    Task<ServiceResponse<NoContent>> Delete(string userId, Guid exerciseId);
}
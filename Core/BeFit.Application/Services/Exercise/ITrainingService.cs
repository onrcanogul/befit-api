namespace BeFit.Application.Services.Exercise;

public interface ITrainingService
{
    Task<ServiceResponse<NoContent>> Add(string userId, TrainingDto model);
    Task<ServiceResponse<NoContent>> Update(string userId, Guid exerciseId, int reps);
    Task<ServiceResponse<NoContent>> Delete(string userId, Guid exerciseId);
    
}
namespace BeFit.Application.Services.Exercise;

public interface IExerciseService<T,TDto> where T : Domain.Entities.Exercise.Exercise where TDto : ExerciseDto
{
    Task<ServiceResponse<List<TDto>>> Get(int page, int size);
    Task<ServiceResponse<TDto>> GetById(Guid id);
    Task<ServiceResponse<NoContent>> Create(TDto exercise);
    Task<ServiceResponse<NoContent>> Update(TDto exercise);
    Task<ServiceResponse<NoContent>> Delete(Guid id);
}
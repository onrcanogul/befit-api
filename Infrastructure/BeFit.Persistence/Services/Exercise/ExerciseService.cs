using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.Repositories;
using BeFit.Application.Services.Exercise;
using BeFit.Domain.Entities.Identity;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services.Exercise;

public class ExerciseService<T, TDto>(IRepository<T> repository, Microsoft.AspNetCore.Identity.UserManager<User> userRepository, IUnitOfWork uow, IMapper mapper)
    : IExerciseService<T, TDto> where T : Domain.Entities.Exercise.Exercise where TDto : ExerciseDto
{
    public async Task<ServiceResponse<List<TDto>>> Get(int page, int size)
    {
        var exercises = await repository.GetQueryable()
            .Skip(page * size)
            .Take(size)
            .ToListAsync();
        var dto = mapper.Map<List<TDto>>(exercises);
        return ServiceResponse<List<TDto>>.Success(dto, StatusCodes.Status200OK);
    }
    public async Task<ServiceResponse<TDto>> GetById(Guid id)
    {
        var exercise = await repository.GetByIdQueryable(id).FirstOrDefaultAsync();
        var dto = mapper.Map<TDto>(exercise);
        return ServiceResponse<TDto>.Success(dto, StatusCodes.Status200OK);
    }
    public async Task<ServiceResponse<NoContent>> Create(TDto exercise)
    {
        exercise.Id = Guid.NewGuid();
        var currentExercise = mapper.Map<T>(exercise);
        await repository.CreateAsync(currentExercise);
        await uow.SaveChangesAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
    }
    public async Task<ServiceResponse<NoContent>> Update(TDto exercise)
    {
        var currentExercise = await repository.GetQueryable().FirstOrDefaultAsync(x => x.Id == exercise.Id)
            ?? throw new NotFoundException("Exercise not found");
        currentExercise.Description = exercise.Description;
        currentExercise.Name = exercise.Name;
        currentExercise.WOBurnedCalorie = exercise.WOBurnedCalorie;
        repository.Update(currentExercise);
        await uow.SaveChangesAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }
    public async Task<ServiceResponse<NoContent>> Delete(Guid id)
    {
        var currentExercise = await repository.GetByIdQueryable(id).FirstOrDefaultAsync()
                              ?? throw new NotFoundException("Exercise Not Found");
        repository.Delete(currentExercise);
        await uow.SaveChangesAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }
}


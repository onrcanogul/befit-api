using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.Repositories;
using BeFit.Application.Services.Exercise;
using BeFit.Domain.Entities;
using BeFit.Domain.Entities.Identity;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services.Exercise;

public class TrainingService(UserManager<User> userRepository, IMapper mapper, IRepository<Training> repository, IUnitOfWork uow)
: ITrainingService
{
    public async Task<ServiceResponse<NoContent>> Add(string userId, TrainingDto model)
    {
        ArgumentNullException.ThrowIfNull(model, nameof(model));
        var user = await userRepository.FindByIdAsync(userId) ?? throw new NotFoundException("user not found");
        var training = mapper.Map<TrainingDto, Training>(model);
        user.Trainings.Add(training);
        await userRepository.UpdateAsync(user);
        return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
    }

    public async Task<ServiceResponse<NoContent>> Update(string userId, Guid exerciseId ,int reps)
    {
        var user = await userRepository.Users.FirstOrDefaultAsync(x => x.Id == userId) 
                   ?? throw new NotFoundException("user not found");
        
        var training = user.Trainings.FirstOrDefault(x => x.Id == exerciseId)
                       ?? throw new NotFoundException("exercise not found");
        training.Reps = reps;
        repository.Update(training);
        await uow.SaveChangesAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }

    public async Task<ServiceResponse<NoContent>> Delete(string userId, Guid exerciseId)
    {
        var user = await userRepository.Users.FirstOrDefaultAsync(x => x.Id == userId) 
                   ?? throw new NotFoundException("user not found");
        var training = await repository.GetByIdQueryable(exerciseId).FirstOrDefaultAsync()
            ?? throw new NotFoundException("exercise not found");
        user.Trainings.Remove(training);
        await userRepository.UpdateAsync(user);
        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }
}
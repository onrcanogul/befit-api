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

public class CardioService(UserManager<User> userRepository, IMapper mapper, IRepository<Cardio> repository, IUnitOfWork uow)
    : ICardioService
{
    public async Task<ServiceResponse<NoContent>> Add(string userId, CardioDto model)
    {
        ArgumentNullException.ThrowIfNull(model, nameof(model));
        var user = await userRepository.FindByIdAsync(userId) ?? throw new NotFoundException("user not found");
        var cardio = mapper.Map<CardioDto, Cardio>(model);
        user.Cardios.Add(cardio);
        await userRepository.UpdateAsync(user);
        return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
    }

    public async Task<ServiceResponse<NoContent>> Update(string userId, Guid exerciseId ,decimal minutes)
    {
        var user = await userRepository.Users.FirstOrDefaultAsync(x => x.Id == userId) 
                   ?? throw new NotFoundException("user not found");
        
        var cardio = user.Cardios.FirstOrDefault(x => x.Id == exerciseId)
                     ?? throw new NotFoundException("exercise not found");
        cardio.Minutes = minutes;
        repository.Update(cardio);
        await uow.SaveChangesAsync();

        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }

    public async Task<ServiceResponse<NoContent>> Delete(string userId, Guid exerciseId)
    {
        var user = await userRepository.Users.FirstOrDefaultAsync(x => x.Id == userId) 
                   ?? throw new NotFoundException("user not found");
        var cardio = await repository.GetByIdQueryable(exerciseId).FirstOrDefaultAsync()
            ?? throw new NotFoundException("exercise not found");
        user.Cardios.Remove(cardio);
        await userRepository.UpdateAsync(user);
        
        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }
}
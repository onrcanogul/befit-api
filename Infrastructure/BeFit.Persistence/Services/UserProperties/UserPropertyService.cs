using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.DataTransferObjects.Create;
using BeFit.Application.DataTransferObjects.Update;
using BeFit.Application.Repositories;
using BeFit.Application.Services.Identity;
using BeFit.Domain.Entities;
using BeFit.Domain.Entities.Enums;
using BeFit.Domain.Entities.Identity;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services.Identity
{
    public class UserPropertyService(IRepository<UserProperties> repository, Microsoft.AspNetCore.Identity.UserManager<User> userRepository,IMapper mapper, IUnitOfWork uow) : IUserPropertyService
    {
        public async Task<ServiceResponse<UserPropertiesDto>> Get(string userId)
        {
            var userExist = await userRepository.Users.AnyAsync(x => x.Id == userId);
            if(!userExist)
                throw new NotFoundException($"User with id {userId} not found");
            var userProperties = await repository.GetQueryable()
                .Where(x => x.UserId == userId)
                .Include(x => x.Activity)
                .Include(x => x.User)
                .FirstOrDefaultAsync() ?? throw new NotFoundException($"User Properties with id {userId} not found");
            
            var dto = mapper.Map<UserPropertiesDto>(userProperties);
            return ServiceResponse<UserPropertiesDto>.Success(dto,StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<NoContent>> Create(CreateUserPropertiesDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(model));
            var entity = mapper.Map<UserProperties>(model);
            FillProperties(entity);
            await repository.CreateAsync(entity);
            await uow.SaveChangesAsync();
            return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
        }
        public async Task<ServiceResponse<NoContent>> Update(UpdateUserPropertiesDto model)
        {
            var userProperty = mapper.Map<UserProperties>(model);
            userProperty.Height = model.Height;
            userProperty.Weight = model.Weight;
            userProperty.Activity = model.Activity;
            userProperty.BodyDecision = model.BodyDecision;
            FillProperties(userProperty);
            repository.Update(userProperty);
            await uow.SaveChangesAsync();
            return ServiceResponse<NoContent>.Success(StatusCodes.Status204NoContent);
        }
        private static void FillProperties(UserProperties model)
        {
            model.MaintenanceCalories = CalculateMaintenanceCalories(model);
            model.FatBurnCalories = CalculateFatBurnCalories(model);
            model.WeightGainCalories = CalculateWeightGainCalories(model);
            model.SuggestedWeight = CalculateSuggestedWeight(model);
            model.SuggestedFatRate = CalculateSuggestedFatRate(model);
            model.NeededProtein = CalculateNeededProtein(model); //make primitive
            model.NeededCarbohydrate = CalculateNeededCarb(model); //make primitive
            model.NeededFat = CalculateNeededFat(model); //make primitive
        }
        private static decimal CalculateMaintenanceCalories(UserProperties model)
        {
            return model.Activity!.ActivityCoefficient * model.BMR;
        }
        private static decimal CalculateFatBurnCalories(UserProperties model)
        {
            return model.Activity!.ActivityCoefficient * model.BMR - 200;
        }
        private static decimal CalculateWeightGainCalories(UserProperties model)
        {
            var calorie = CalculateMaintenanceCalories(model);
            calorie = (calorie * (decimal)0.2);
            return calorie;
        }
        private static decimal CalculateSuggestedWeight(UserProperties model)
        {
            return (decimal)24.9 * (model.Height * model.Height);
        }
        private static decimal CalculateSuggestedFatRate(UserProperties model)
        {
            var fatRate = ((decimal)1.20 * model.Weight / (model.Height * model.Height)) + ((decimal)0.23 * (decimal)model.User.Age);
            fatRate -= model.User.Gender switch
            {
                Gender.Male => (decimal)5.4,
                Gender.Female => (decimal)16.2,
                _ => throw new ArgumentOutOfRangeException()
            };
            return fatRate;
        }
        private static decimal CalculateNeededProtein(UserProperties model)
        {
            var bodyWeightWithoutFat = model.Weight - ((model.Weight * model.FatRate) / 100);
            var protein = model.BodyDecision switch
            {
                BodyDecision.LoseFat => bodyWeightWithoutFat * (decimal)2.5,
                BodyDecision.MaintainWeight => bodyWeightWithoutFat * (decimal)1.9,
                _ => bodyWeightWithoutFat * (decimal)2.2
            };
            return protein;
        }
        private static decimal CalculateNeededFat(UserProperties model)
        {
            var bodyWeightWithoutFat = model.Weight - ((model.Weight * model.FatRate) / 100);
            var fat = model.BodyDecision switch
            {
                BodyDecision.LoseFat => bodyWeightWithoutFat * (decimal)1.1,
                BodyDecision.MaintainWeight => ((model.DailyCalories * 25) / 100) / 9,
                _ => bodyWeightWithoutFat * (decimal)1.5 //?
            };
            return fat;
        }
        private static decimal CalculateNeededCarb(UserProperties model)
        {
            var fat = CalculateNeededFat(model);
            var protein = CalculateNeededProtein(model);
            var fatCalorie = fat * 9;
            var proteinCalorie = protein * 4;
            var carb = (model.DailyCalories - (fatCalorie + proteinCalorie)) / 4;
            return carb;
        }
    }
}

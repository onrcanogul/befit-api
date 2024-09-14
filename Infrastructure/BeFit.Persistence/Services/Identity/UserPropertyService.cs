using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.Repositories;
using BeFit.Application.Services.Identity;
using BeFit.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace BeFit.Persistence.Services.Identity
{
    public class UserPropertyService(IRepository<UserProperties> repository, IMapper mapper, IUnitOfWork uow) : IUserPropertyService
    {
        public async Task<ServiceResponse<NoContent>> CreateUserProperties(UserPropertiesDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(model));

            model.MaintenanceCalories = CalculateMaintenanceCalories(model);
            model.FatBurnCalories = CalculateFatBurnCalories(model);
            model.WeightGainCalories = CalculateWeightGainCalories(model);
            model.SuggestedWeight = CalculateSuggestedWeight(model);
            model.SuggestedFatRate = CalculateSuggestedFatRate(model);
            model.NeededProtein.Weight = CalculateNeededProtein(model);
            model.NeededCarbohydrate.Weight = CalculateNeededCarb(model);
            model.NeededFat.Weight = CalculateNeededFat(model);

            var entity = mapper.Map<UserProperties>(model);

            await repository.CreateAsync(entity);
            await uow.SaveChangesAsync();

            return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
        }


        private decimal CalculateMaintenanceCalories(UserPropertiesDto model)
        {
            return model.Activity!.ActivityCoefficient * model.BMR;
        }
        private decimal CalculateFatBurnCalories(UserPropertiesDto model)
        {
            return default;
        }
        private decimal CalculateWeightGainCalories(UserPropertiesDto model)
        {
            var calorie = CalculateMaintenanceCalories(model);
            return calorie += (calorie * (decimal)0.2);
        }
        private decimal CalculateSuggestedWeight(UserPropertiesDto model)
        {
            return (decimal)24.9 * (model.Height * model.Height);
        }
        private decimal CalculateSuggestedFatRate(UserPropertiesDto model)
        {
            var fatRate = ((decimal)1.20 * model.Weight / (model.Height * model.Height)) + ((decimal)0.23 * (decimal)model.User.Age);

            switch (model.User.Gender)
            {
                case Gender.Male:
                    fatRate -= (decimal)5.4;
                    break;
                case Gender.Female:
                    fatRate -= (decimal)16.2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return fatRate;
        }
        private decimal CalculateNeededProtein(UserPropertiesDto model) //bunları karara bağlamak lazım --> yağ yakmak, kilo kazanmak vsvs.
        {
            return model.Weight * model.Activity!.ActivityCoefficient;
        }
        private decimal CalculateNeededFat(UserPropertiesDto model)
        {
            return (model.DailyCalories * (decimal)0.25)/9;
        }
        private decimal CalculateNeededCarb(UserPropertiesDto model)
        {
            return default;
        }
    }
}

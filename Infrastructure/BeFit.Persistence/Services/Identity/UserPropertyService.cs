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
            return default;
        }
        private decimal CalculateFatBurnCalories(UserPropertiesDto model)
        {
            return default;
        }
        private decimal CalculateWeightGainCalories(UserPropertiesDto model)
        {
            return default;
        }
        private decimal CalculateSuggestedWeight(UserPropertiesDto model)
        {
            return default;
        }
        private decimal CalculateSuggestedFatRate(UserPropertiesDto model)
        {
            return default;
        }
        private decimal CalculateNeededProtein(UserPropertiesDto model)
        {
            return default;
        }
        private decimal CalculateNeededFat(UserPropertiesDto model)
        {
            return default;
        }
        private decimal CalculateNeededCarb(UserPropertiesDto model)
        {
            return default;
        }
    }
}

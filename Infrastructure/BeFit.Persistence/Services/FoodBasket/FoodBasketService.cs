using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects.FoodBasket;
using BeFit.Application.Repositories;
using BeFit.Application.Services.FoodBasket;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services.FoodBasket;

public class FoodBasketService(IRepository<Domain.Entities.FoodBasket.FoodBasket> repository, IRepository<Domain.Entities.Abstract.Nutrient> nutrientRepository, IMapper mapper, IUnitOfWork uow)
: IFoodBasketService
{
    public async Task<ServiceResponse<FoodBasketDto>> Get(string userId)
    {
        var basket = await repository.GetQueryable()
                .Include(x => x.Nutrients)
                     .ThenInclude(x => x.Nutrient)
                        .ThenInclude(x => x.Properties).FirstOrDefaultAsync(x => x.UserId == userId)
            ?? throw new NotFoundException("Food basket not found");
        
        var dto = mapper.Map<FoodBasketDto>(basket);
        SetProperties(dto);
        SetTotals(dto);
        return ServiceResponse<FoodBasketDto>.Success(dto, StatusCodes.Status200OK);
    }
    public async Task<ServiceResponse<NoContent>> Create(string userId)
    {
        var basket = new Domain.Entities.FoodBasket.FoodBasket { UserId = userId, Id = Guid.NewGuid() };
        await repository.CreateAsync(basket);
        await uow.SaveChangesAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
    }
    
    public async Task<ServiceResponse<FoodBasketDto>> Save(SaveBasketDto model)
    {
        var basket = await repository.GetQueryable(x => x.Id == model.BasketId)
                         .Include(x => x.Nutrients)
                         .FirstOrDefaultAsync()
                     ?? throw new NotFoundException("Food basket not found");
        UpdateBasketNutrients(basket, model.NewItems);
        SetTotals(mapper.Map<FoodBasketDto>(model));
        await uow.SaveChangesAsync();
        var dto = mapper.Map<FoodBasketDto>(basket);
        return ServiceResponse<FoodBasketDto>.Success(dto, StatusCodes.Status200OK);
    }
    
    public async Task<ServiceResponse<NoContent>> Clear(Guid basketId)
    {
        var basket = await repository.GetQueryable()
            .Include(x => x.Nutrients)
            .FirstOrDefaultAsync() ?? throw new NotFoundException("food basket not found");
        basket.Nutrients.Clear();
        repository.Update(basket);
        await uow.SaveChangesAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }
    
    private static void SetProperties(FoodBasketDto basket)
    {
        basket.Nutrients.ForEach(x =>
        {
            x.Nutrient.Properties.Calories = x.Nutrient.Properties.Calories * x.Measure / 100;
            x.Nutrient.Properties.Carbohydrate = x.Nutrient.Properties.Carbohydrate100gr * x.Measure / 100;
            x.Nutrient.Properties.Protein = x.Nutrient.Properties.Protein100gr * x.Measure / 100;
            x.Nutrient.Properties.Fat = x.Nutrient.Properties.Fat100gr * x.Measure / 100;
            x.Nutrient.Properties.Magnesium = x.Nutrient.Properties.Magnesium100gr * x.Measure / 100;
            x.Nutrient.Properties.Salt = x.Nutrient.Properties.Salt100gr * x.Measure / 100;
            x.Nutrient.Properties.CholesterolWeight = x.Nutrient.Properties.CholesterolWeight100gr * x.Measure / 100;
            x.Nutrient.Properties.Sodium = x.Nutrient.Properties.Sodium100gr * x.Measure / 100;
            x.Nutrient.Properties.SugarWeight = x.Nutrient.Properties.SugarWeight100gr * x.Measure / 100;
        });
    }
    
    private void UpdateBasketNutrients(Domain.Entities.FoodBasket.FoodBasket basket, List<BasketItemDto> newItems)
    { 
        foreach (var newItem in newItems)
            mapper.Map(newItem, basket.Nutrients.First(n => n.Id == newItem.Id));
        repository.Update(basket);
    }
    private static void SetTotals(FoodBasketDto basket) //includelere bakılcak
    {
       basket.TotalCalorie = basket.Nutrients.Sum(x => x.Nutrient.Properties.Calories);
       basket.TotalCarb = basket.Nutrients.Sum(x => x.Nutrient.Properties.Carbohydrate);
       basket.TotalProtein = basket.Nutrients.Sum(x => x.Nutrient.Properties.Protein);
       basket.TotalFat = basket.Nutrients.Sum(x => x.Nutrient.Properties.Fat);
       basket.TotalMagnesium = basket.Nutrients.Sum(x => x.Nutrient.Properties.Magnesium);
       basket.TotalCholesterol = basket.Nutrients.Sum(x => x.Nutrient.Properties.CholesterolWeight);
       basket.TotalSodium = basket.Nutrients.Sum(x => x.Nutrient.Properties.Sodium);
       basket.TotalSalt = basket.Nutrients.Sum(x => x.Nutrient.Properties.Salt);
       basket.TotalSugar = basket.Nutrients.Sum(x => x.Nutrient.Properties.SugarWeight);
    }
}
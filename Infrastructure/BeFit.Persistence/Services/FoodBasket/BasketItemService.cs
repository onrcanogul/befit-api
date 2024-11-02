using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects.FoodBasket;
using BeFit.Application.Repositories;
using BeFit.Application.Services.FoodBasket;
using BeFit.Domain.Entities.FoodBasket;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BeFit.Persistence.Services.FoodBasket;

public class BasketItemService(IRepository<BasketItem> repository,IRepository<Domain.Entities.FoodBasket.FoodBasket> basketRepository, IMapper mapper, IUnitOfWork uow)
: IBasketItemService
{
    public async Task<ServiceResponse<NoContent>> Add(AddItemDto model)
    {
        var basket = await basketRepository
                         .GetQueryable(x => x.UserId == model.UserId.ToString())
                         .Include(x => x.Nutrients)
                         .FirstOrDefaultAsync()
            ?? throw new NotFoundException("Basket not found");
        var basketItem = basket.Nutrients.FirstOrDefault(x => x.NutrientId == model.NutrientId);
        if (basketItem != null)
            basketItem.Measure += model.Grammage;
        else
            basket.Nutrients.Add(new BasketItem
            {
                NutrientId = model.NutrientId, Measure = model.Grammage
            });
        basketRepository.Update(basket);
        await uow.SaveChangesAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }
    public async Task<ServiceResponse<NoContent>> Delete(Guid id)
    {
        var basketItem = await repository.GetQueryable().FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new NotFoundException("Basket item not found");
        repository.Delete(basketItem);
        await uow.SaveChangesAsync();
        
        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }

    public async Task<ServiceResponse<NoContent>> Update(Guid id, Guid nutrientId, decimal measure)
    {
        var basketItem = await repository.GetQueryable().FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new NotFoundException("Basket item not found");
        basketItem.Measure = measure;
        
        repository.Update(basketItem);
        await uow.SaveChangesAsync();
        
        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }
}
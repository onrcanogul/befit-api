using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects.FoodBasket;
using BeFit.Application.Repositories;
using BeFit.Application.Services.FoodBasket;
using BeFit.Domain.Entities.FoodBasket;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services.FoodBasket;

public class BasketItemService(IRepository<BasketItem> repository, IMapper mapper, IUnitOfWork uow)
: IBasketItemService
{
    public async Task<ServiceResponse<NoContent>> Add(AddItemDto model)
    {
        var basketItem = new BasketItem
        {
            NutrientId = model.NutrientId, BasketId = model.BasketId, Measure = model.Grammage
        };
        await repository.CreateAsync(basketItem);
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
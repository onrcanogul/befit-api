namespace BeFit.Application.DataTransferObjects.FoodBasket;

public class SaveBasketDto
{
    public Guid BasketId { get; set; }
    public List<BasketItemDto> NewItems { get; set; }
}
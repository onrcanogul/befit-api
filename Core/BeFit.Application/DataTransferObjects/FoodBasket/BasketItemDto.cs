namespace BeFit.Application.DataTransferObjects.FoodBasket;

public class BasketItemDto
{
    public Guid NutrientId { get; set; }
    public Guid BasketId { get; set; }
    public NutrientDto Nutrient { get; set; }
    public FoodBasketDto Basket { get; set; }
    public decimal Grammage { get; set; }
}
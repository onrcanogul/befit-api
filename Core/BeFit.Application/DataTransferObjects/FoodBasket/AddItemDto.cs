namespace BeFit.Application.DataTransferObjects.FoodBasket;

public class AddItemDto
{
    public Guid NutrientId { get; set; }
    public Guid BasketId { get; set; }
    public decimal Grammage { get; set; }
}
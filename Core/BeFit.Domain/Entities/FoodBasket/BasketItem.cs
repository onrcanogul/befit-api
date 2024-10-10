using BeFit.Domain.Entities.Abstract;
using BeFit.Domain.Entities.Base;

namespace BeFit.Domain.Entities.FoodBasket;

public class BasketItem : BaseEntity
{
    public Guid NutrientId { get; set; }
    public Guid BasketId { get; set; }
    public Nutrient Nutrient { get; set; }
    public decimal Measure { get; set; }
    public FoodBasket Basket { get; set; }
}
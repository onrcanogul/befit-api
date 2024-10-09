using BeFit.Domain.Entities.Abstract;
using BeFit.Domain.Entities.Base;
using BeFit.Domain.Entities.Identity;

namespace BeFit.Domain.Entities.FoodBasket;

public class FoodBasket : BaseEntity
{
    public string UserId { get; set; }
    public List<BasketItem> Nutrients { get; set; } = new();
    public decimal TotalCalorie { get; set; }
    public decimal TotalCarb { get; set; }
    public decimal TotalProtein { get; set; }
    public decimal TotalFat { get; set; }
    public decimal TotalSalt { get; set; }
    public decimal TotalSugar { get; set; }
    public decimal TotalSodium { get; set; }
    public decimal TotalMagnesium { get; set; }
    public decimal TotalCholesterol { get; set; }
}
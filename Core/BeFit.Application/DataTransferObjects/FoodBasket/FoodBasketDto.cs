namespace BeFit.Application.DataTransferObjects.FoodBasket;

public class FoodBasketDto : BaseDto
{
    public string UserId { get; set; }
    public List<BasketItemDto> Nutrients { get; set; } = new();
    public UserDto User { get; set; }  
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
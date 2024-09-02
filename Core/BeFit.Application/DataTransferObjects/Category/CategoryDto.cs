namespace BeFit.Application.DataTransferObjects
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public List<FoodDto> Foods { get; set; } = new();
        public List<DrinkDto> Drinks { get; set; } = new();
        public List<CategoryImageDto> Images { get; set; } = new();
    }
}

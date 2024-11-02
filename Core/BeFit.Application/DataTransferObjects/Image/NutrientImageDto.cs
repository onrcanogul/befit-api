namespace BeFit.Application.DataTransferObjects
{
    public class NutrientImageDto : ImageDto
    {
        public Guid FoodId { get; set; }
        public FoodDto? Food { get; set; } = null!;
    }
}

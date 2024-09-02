namespace BeFit.Domain.Entities
{
    public class FoodImage : Image
    {
        public Guid FoodId { get; set; }
        public Food Food { get; set; } = null!;
    }
}

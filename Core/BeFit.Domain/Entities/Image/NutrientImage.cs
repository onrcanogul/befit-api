using BeFit.Domain.Entities.Abstract;

namespace BeFit.Domain.Entities
{
    public class NutrientImage : Image
    {
        public Guid NutrientId { get; set; }
        public Nutrient Nutrient { get; set; } = null!;
    }
}

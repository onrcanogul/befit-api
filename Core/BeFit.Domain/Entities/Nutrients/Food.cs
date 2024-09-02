using BeFit.Domain.Entities.Abstract;

namespace BeFit.Domain.Entities
{
    public class Food : Nutrient
    {
        public List<NutrientImage> Images { get; set; } = new();
    }
}

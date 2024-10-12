using BeFit.Domain.Entities.Base;

namespace BeFit.Domain.Entities.Abstract
{
    public class Nutrient : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        
        public Guid PropertiesId { get; set; }
        public NutrientProperties Properties { get; set; } = null!;
        public List<NutrientImage> Images { get; set; } = null!;
        public List<Category> Categories { get; set; } = new();

    }
}

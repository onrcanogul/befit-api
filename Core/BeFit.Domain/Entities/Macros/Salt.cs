using BeFit.Domain.Entities.Base;

namespace BeFit.Domain.Entities
{
    public class Salt : BaseEntity
    {
        public decimal Weight { get; set; }
        public Guid NutrientPropertiesId { get; set; }
        public NutrientProperties NutrientProperties { get; set; } = null!;
    }
}

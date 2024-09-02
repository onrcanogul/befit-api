using BeFit.Domain.Entities.Base;

namespace BeFit.Domain.Entities
{
    public class Minerals : BaseEntity
    {
        public decimal Calcium { get; set; } = default;
        public decimal Sulfur { get; set; } = default;
        public decimal Iron { get; set; } = default;
        public decimal Potassium { get; set; } = default;
        public decimal Sodium { get; set; } = default;
        public decimal Magnesium { get; set; } = default;
        public decimal Phosphorus { get; set; } = default;
        public Guid NutrientPropertiesId { get; set; }
        public NutrientProperties NutrientProperties { get; set; } = null!;
    }
}

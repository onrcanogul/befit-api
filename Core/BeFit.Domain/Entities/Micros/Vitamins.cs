using BeFit.Domain.Entities.Base;

namespace BeFit.Domain.Entities
{
    public class Vitamins : BaseEntity
    {
        public decimal B2 { get; set; } = default!;
        public decimal B1 { get; set; } = default!;
        public decimal B3 { get; set; } = default!;
        public decimal B12 { get; set; } = default!;
        public decimal E { get; set; } = default!;
        public decimal FolicAcid { get; set; } = default!;
        public Guid NutrientPropertiesId { get; set; }
        public NutrientProperties NutrientProperties { get; set; } = null!;
    }
}

using BeFit.Domain.Entities.Base;

namespace BeFit.Domain.Entities.Macros
{
    public class Protein : BaseEntity
    {
        public decimal Weight { get; set; } = default; //gram
        public Guid NutrientPropertiesId { get; set; }    
        public NutrientProperties NutrientProperties { get; set; } = null!;
    }
}

using BeFit.Domain.Entities.Abstract;
using BeFit.Domain.Entities.Base;

namespace BeFit.Domain.Entities.Macros
{
    public class Fat : BaseEntity
    {
        public decimal Weight { get; set; } = default!; //gram
        public decimal CholesterolWeight { get; set; } = default!; //miligram
        public Guid NutrientPropertiesId { get; set; }
        public NutrientProperties NutrientProperties { get; set; } = null!;
    }
}

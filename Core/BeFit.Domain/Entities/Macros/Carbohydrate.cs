using BeFit.Domain.Entities.Abstract;
using BeFit.Domain.Entities.Base;

namespace BeFit.Domain.Entities.Macros
{
    public class Carbohydrate : BaseEntity
    {
        public decimal Weight { get; set; } = default!; //gram
        public decimal SugarWeight { get; set; } = default!; //gram
        public Guid NutrientPropertiesId { get; set; }
        public NutrientProperties NutrientProperties { get; set; } = null!;
    }
}

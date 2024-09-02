using BeFit.Domain.Entities.Abstract;
using BeFit.Domain.Entities.Base;
using BeFit.Domain.Entities.Macros;

namespace BeFit.Domain.Entities
{
    public class NutrientProperties : BaseEntity
    {
        public Guid NutrientId { get; set; }
        public decimal Calories { get; set; }
        
        //Macros
        public Protein Protein { get; set; } = null!;
        public Fat Fat { get; set; } = null!;
        public Carbohydrate Carbohydrate { get; set; } = null!;
        public Salt Salt { get; set; } = null!;

        //Micros
        public Vitamins Vitamins { get; set; } = null!;
        public Minerals Minerals { get; set; } = null!;
        //Navigation
        public Nutrient Nutrient { get; set; } = null!;
        
    }
}

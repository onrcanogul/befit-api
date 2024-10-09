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
        public decimal Protein100gr { get; set; } = default!;
        public decimal Fat100gr { get; set; } = default!;
        public decimal CholesterolWeight100gr { get; set; } = default!; //miligram
        public decimal Carbohydrate100gr { get; set; } = default!;
        public decimal Salt100gr { get; set; } = default!;
        public decimal SugarWeight100gr { get; set; } = default!;
        //Micros
        public decimal Sodium100gr { get; set; } = default;
        public decimal Magnesium100gr { get; set; } = default;
        

        //Navigation
        public Nutrient Nutrient { get; set; } = null!;
        public List<FoodBasket.FoodBasket> Baskets { get; set; } = new();

    }
}

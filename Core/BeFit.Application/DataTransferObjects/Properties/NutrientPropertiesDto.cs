using System.Text.Json.Serialization;
using BeFit.Application.DataTransferObjects.FoodBasket;
using BeFit.Domain.Entities.FoodBasket;

namespace BeFit.Application.DataTransferObjects
{
    public class NutrientPropertiesDto : BaseDto
    {
        public Guid NutrientId { get; set; }
        public decimal Calories { get; set; }
        //Macros
        public decimal Protein100gr { get; set; } = default!;
        public decimal Fat100gr { get; set; } = default!;
        public decimal CholesterolWeight100gr { get; set; } = default!;
        public decimal Carbohydrate100gr { get; set; } = default!;
        public decimal Salt100gr { get; set; } = default!;
        public decimal SugarWeight100gr { get; set; } = default!;
        //Micros

        public decimal Sodium100gr { get; set; } = default;
        public decimal Magnesium100gr { get; set; } = default;
        
        //Macros
        public decimal Protein { get; set; }
        public decimal Fat { get; set; }
        public decimal CholesterolWeight { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Salt { get; set; }
        public decimal SugarWeight { get; set; }
        //Micros
        public decimal Sodium { get; set; }
        public decimal Magnesium { get; set; }

        
        //Navigation
        [JsonIgnore]
        public NutrientDto? Nutrient { get; set; } = null!;

    }
}

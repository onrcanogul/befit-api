using System.Text.Json.Serialization;

namespace BeFit.Application.DataTransferObjects
{
    public class NutrientPropertiesDto : BaseDto
    {
        public Guid NutrientId { get; set; }
        public decimal Calories { get; set; }
        
        //Macros
        public decimal Protein { get; set; } = default!;
        public decimal Fat { get; set; } = default!;
        public decimal CholesterolWeight { get; set; } = default!; //miligram
        public decimal Carbohydrate { get; set; } = default!;
        public decimal Salt { get; set; } = default!;
        public decimal SugarWeight { get; set; } = default!;
        //Micros
        public decimal B2 { get; set; } = default!;
        public decimal B1 { get; set; } = default!;
        public decimal B3 { get; set; } = default!;
        public decimal B12 { get; set; } = default!;
        public decimal E { get; set; } = default!;
        public decimal FolicAcid { get; set; } = default!;
        public decimal Calcium { get; set; } = default;
        public decimal Sulfur { get; set; } = default;
        public decimal Iron { get; set; } = default;
        public decimal Potassium { get; set; } = default;
        public decimal Sodium { get; set; } = default;
        public decimal Magnesium { get; set; } = default;
        public decimal Phosphorus { get; set; } = default;
        //Navigation
        [JsonIgnore]
        public NutrientDto? Nutrient { get; set; } = null!;
    }
}

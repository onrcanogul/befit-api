namespace BeFit.Application.DataTransferObjects
{
    public class MineralsDto : BaseDto
    {
        public decimal Calcium { get; set; } = default;
        public decimal Sulfur { get; set; } = default;
        public decimal Iron { get; set; } = default;
        public decimal Potassium { get; set; } = default;
        public decimal Sodium { get; set; } = default;
        public decimal Magnesium { get; set; } = default;
        public decimal Phosphorus { get; set; } = default;
        public Guid NutrientPropertiesId { get; set; }
        public NutrientPropertiesDto NutrientProperties { get; set; } = null!;
    }
}

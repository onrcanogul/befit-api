namespace BeFit.Application.DataTransferObjects
{
    public class CarbohydrateDto : BaseDto
    {
        public decimal Weight { get; set; } = default!; //gram
        public decimal SugarWeight { get; set; } = default!; //gram
        public Guid NutrientPropertiesId { get; set; }
        public NutrientPropertiesDto NutrientProperties { get; set; } = null!;
    }
}

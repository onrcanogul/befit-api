namespace BeFit.Application.DataTransferObjects
{
    public class ProteinDto : BaseDto
    {
        public decimal Weight { get; set; } = default; //gram
        public Guid NutrientPropertiesId { get; set; }
        public NutrientPropertiesDto NutrientProperties { get; set; } = null!;
    }
}

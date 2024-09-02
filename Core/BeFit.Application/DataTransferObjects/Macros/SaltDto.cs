namespace BeFit.Application.DataTransferObjects
{
    public class SaltDto
    {
        public decimal Weight { get; set; }
        public Guid NutrientPropertiesId { get; set; }
        public NutrientPropertiesDto NutrientProperties { get; set; } = null!;
    }
}

namespace BeFit.Application.DataTransferObjects
{
    public class FatDto : BaseDto
    {
        public decimal? Weight { get; set; } = default!; //gram
        public decimal? CholesterolWeight { get; set; } = default!; //miligram
        public Guid NutrientPropertiesId { get; set; }
        public NutrientPropertiesDto NutrientProperties { get; set; } = null!;
    }
}

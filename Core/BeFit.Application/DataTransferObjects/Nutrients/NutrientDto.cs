namespace BeFit.Application.DataTransferObjects
{
    public abstract class NutrientDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid PropertyId { get; set; }
        public NutrientPropertiesDto Properties { get; set; } = null!;
    }
}

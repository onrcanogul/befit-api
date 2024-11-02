namespace BeFit.Application.DataTransferObjects
{
    public class NutrientDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public NutrientPropertiesDto? Properties { get; set; } = null!;
        public Guid ImageId { get; set; }
        public NutrientImageDto? Image { get; set; } = null!;
        public List<CategoryDto> Categories { get; set; } = new();
    }
}

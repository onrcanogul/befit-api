namespace BeFit.Application.DataTransferObjects
{
    public class CreateNutrientDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Calories { get; set; }
        public NutrientPropertiesDto Properties { get; set; } = null!;
    }
}

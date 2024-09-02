namespace BeFit.Application.DataTransferObjects.Nutrients.CreateDtos
{
    public class UpdateNutrientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Calories { get; set; }

        public NutrientPropertiesDto Properties { get; set; } = null!;
    }
}

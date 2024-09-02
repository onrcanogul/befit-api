namespace BeFit.Application.DataTransferObjects
{
    public class NutrientPropertiesDto : BaseDto
    {
        public Guid NutrientId { get; set; }
        public decimal Calories { get; set; }

        //Macros
        public ProteinDto Protein { get; set; } = null!;
        public FatDto Fat { get; set; } = null!;
        public CarbohydrateDto Carbohydrate { get; set; } = null!;
        public SaltDto Salt { get; set; } = null!;

        //Micros
        public VitaminsDto Vitamins { get; set; } = null!;
        public MineralsDto Minerals { get; set; } = null!;
        //Navigation
        public NutrientDto Nutrient { get; set; } = null!;
    }
}

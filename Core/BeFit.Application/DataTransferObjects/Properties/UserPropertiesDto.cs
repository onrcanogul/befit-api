using BeFit.Domain.Entities.Exercise;

namespace BeFit.Application.DataTransferObjects
{
    public class UserPropertiesDto
    {
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal FatRate { get; set; }
        public decimal SuggestedFatRate { get; set; }
        public decimal SuggestedWeight { get; set; }
        public decimal DailyCalories { get; set; }
        public decimal FatBurnCalories { get; set; }
        public decimal WeightGainCalories { get; set; }
        public decimal MaintenanceCalories { get; set; }
        public Activity? Activity { get; set; }
        public ProteinDto NeededProtein { get; set; }  
        public CarbohydrateDto NeededCarbohydrate { get; set; }
        public FatDto NeededFat { get; set; }
        public string UserId { get; set; } = null!;
        public UserDto User { get; set; } = null!;
        public decimal BMR => (10 * Weight) + ((decimal)6.25 * Height) - (5 * User.Age) + 5;

    }
}

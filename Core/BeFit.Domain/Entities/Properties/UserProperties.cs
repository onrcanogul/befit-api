using BeFit.Domain.Entities.Base;
using BeFit.Domain.Entities.Identity;
using BeFit.Domain.Entities.Macros;

namespace BeFit.Domain.Entities
{
    public class UserProperties : BaseEntity
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
        public Protein NeededProtein { get; set; } = null!;
        public Carbohydrate NeededCarbohydrate { get; set; } = null!;
        public Fat NeededFat { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}

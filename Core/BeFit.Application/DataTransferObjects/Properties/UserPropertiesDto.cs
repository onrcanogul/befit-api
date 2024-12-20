﻿using System.Text.Json.Serialization;
using BeFit.Domain.Entities;
using BeFit.Domain.Entities.Enums;
using BeFit.Domain.Entities.Exercise;

namespace BeFit.Application.DataTransferObjects
{
    public class UserPropertiesDto
    {
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal? FatRate { get; set; }
        public decimal? SuggestedFatRate { get; set; }
        public decimal? SuggestedWeight { get; set; }
        public decimal? DailyCalories { get; set; }
        public decimal? FatBurnCalories { get; set; }
        public decimal? WeightGainCalories { get; set; }
        public decimal? MaintenanceCalories { get; set; }
        public Activity? Activity { get; set; }
        public BodyDecision? BodyDecision { get; set; }
        public decimal NeededProtein { get; set; }
        public decimal NeededCarbohydrate { get; set; }
        public decimal NeededFat { get; set; }
        public string UserId { get; set; } = null!;
        [JsonIgnore]
        public UserDto User { get; set; } = null!;
        public decimal BMR => User.Gender == Gender.Male ? (10 * Weight) + ((decimal)6.25 * Height) - (5 * User.Age) + 5 : (10 * Weight) + ((decimal)6.25 * Height) - (5 * User.Age) - 161;

    }
}

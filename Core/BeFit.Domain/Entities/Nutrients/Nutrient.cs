﻿using BeFit.Domain.Entities.Base;

namespace BeFit.Domain.Entities.Abstract
{
    public abstract class Nutrient : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid PropertiesId { get; set; }
        public NutrientProperties Properties { get; set; } = null!;
        public Guid ImageId { get; set; }
        public NutrientImage Image { get; set; } = null!;
    }
}

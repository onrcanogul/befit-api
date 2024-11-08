﻿namespace BeFit.Application.DataTransferObjects
{
    public class VitaminsDto : BaseDto
    {
        public decimal B2 { get; set; } = default!;
        public decimal B1 { get; set; } = default!;
        public decimal B3 { get; set; } = default!;
        public decimal B12 { get; set; } = default!;
        public decimal E { get; set; } = default!;
        public decimal FolicAcid { get; set; } = default!;
        public Guid PropertiesId { get; set; }
        public NutrientPropertiesDto Properties { get; set; } = null!;
    }
}

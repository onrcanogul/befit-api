using BeFit.Domain.Entities.Base;

namespace BeFit.Domain.Entities.Exercise
{
    public class Activity : BaseEntity
    {
        public string Name { get; set; }
        public decimal ActivityCoefficient { get; set; }
    }
}

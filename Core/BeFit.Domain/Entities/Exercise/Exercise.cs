using BeFit.Domain.Entities.Base;

namespace BeFit.Domain.Entities.Exercise;
public class Exercise : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal WOBurnedCalorie { get; set; }

}
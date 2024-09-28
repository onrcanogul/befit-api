namespace BeFit.Domain.Entities;

public class Cardio : Exercise.Exercise
{
    public decimal Minutes { get; set; }
    public decimal BurnedCalorie => WOBurnedCalorie * Minutes / 60;
}
namespace BeFit.Domain.Entities;

public class Training : Exercise.Exercise
{
    public int Reps { get; set; }
    public decimal BurnedCaloriePer12Reps { get; set; }
    public decimal BurnedCalorie => BurnedCaloriePer12Reps * 12 / Reps;
}
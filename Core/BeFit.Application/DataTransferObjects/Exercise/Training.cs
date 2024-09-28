namespace BeFit.Application.DataTransferObjects;

public class TrainingDto : ExerciseDto
{
    public int Reps { get; set; }
    
    public decimal BurnedCalorie => WOBurnedCalorie * 12 / Reps;
}
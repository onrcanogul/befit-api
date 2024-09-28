namespace BeFit.Application.DataTransferObjects;

public class ExerciseDto : BaseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal WOBurnedCalorie { get; set; }
}
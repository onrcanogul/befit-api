namespace BeFit.Application.DataTransferObjects;

public class CardioDto : ExerciseDto
{
    public decimal Minutes { get; set; }
    public decimal BurnedCaloriePerHour { get; set; }
    public decimal BurnedCalorie => WOBurnedCalorie * Minutes / 60;
}
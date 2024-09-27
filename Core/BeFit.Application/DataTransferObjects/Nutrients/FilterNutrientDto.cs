namespace BeFit.Application.DataTransferObjects;

public class FilterNutrientDto
{
    public string Term { get; set; }
    public List<Guid> CategoryIds { get; set; } = new List<Guid>();
    public decimal MinCalorie { get; set; }
    public decimal MaxCalorie { get; set; }
}
namespace BeFit.Application.DataTransferObjects.Update;

public class UpdateCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}
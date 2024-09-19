using BeFit.Domain.Entities.Enums;
using BeFit.Domain.Entities.Exercise;

namespace BeFit.Application.DataTransferObjects.Create;

public class CreateUserPropertiesDto
{
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public decimal? FatRate { get; set; }
    public Guid ActivityId { get; set; }
    public BodyDecision? BodyDecision { get; set; }
    public string UserId { get; set; } = null!;
}
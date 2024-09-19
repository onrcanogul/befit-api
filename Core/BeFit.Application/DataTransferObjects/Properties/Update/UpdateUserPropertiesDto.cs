using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BeFit.Domain.Entities.Enums;
using BeFit.Domain.Entities.Exercise;

namespace BeFit.Application.DataTransferObjects.Update;

public class UpdateUserPropertiesDto
{
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public decimal? FatRate { get; set; }
    public Guid ActivityId { get; set; }
    public BodyDecision? BodyDecision { get; set; }
    public string UserId { get; set; } = null!;
    [JsonIgnore]
    public Activity? Activity { get; set; }
}
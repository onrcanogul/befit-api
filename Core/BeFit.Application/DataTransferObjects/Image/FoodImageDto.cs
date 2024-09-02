using BeFit.Application.Dtos;

namespace BeFit.Application.DataTransferObjects
{
    public class FoodImageDto : ImageDto
    {
        public Guid FoodId { get; set; }
        public FoodDto Food { get; set; } = null!;
    }
}

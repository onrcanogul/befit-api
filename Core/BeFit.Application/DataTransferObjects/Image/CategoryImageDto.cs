namespace BeFit.Application.DataTransferObjects
{
    public class CategoryImageDto : ImageDto
    {
        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; } = null!;
    }
}

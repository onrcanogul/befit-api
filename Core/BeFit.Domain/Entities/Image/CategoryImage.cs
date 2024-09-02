namespace BeFit.Domain.Entities
{
    public class CategoryImage : Image
    {
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}

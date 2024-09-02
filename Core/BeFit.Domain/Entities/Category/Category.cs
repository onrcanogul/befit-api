using BeFit.Domain.Entities.Base;

namespace BeFit.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public List<Food> Foods { get; set; } = new();
        public List<Drink> Drinks { get; set; } = new();
        public List<CategoryImage> Images { get; set; } = new();
    }
}

using BeFit.Domain.Entities.Abstract;
using BeFit.Domain.Entities.Base;

namespace BeFit.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public List<Nutrient> Nutrients { get; set; } = new();
        public List<CategoryImage> Images { get; set; } = new();
    }
}

using BeFit.Domain.Entities.Base;

namespace BeFit.Domain.Entities
{
    public abstract class Image : BaseEntity
    {
        public string Path { get; set; } = null!;
        public string FileName { get; set; } = null!;
    }
}

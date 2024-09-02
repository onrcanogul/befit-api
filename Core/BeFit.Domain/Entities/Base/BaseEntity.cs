namespace BeFit.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
    }
}

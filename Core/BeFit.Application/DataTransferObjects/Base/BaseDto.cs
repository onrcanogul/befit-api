namespace BeFit.Application.DataTransferObjects
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; }
        public virtual DateTime UpdatedDate { get; }
    }
}

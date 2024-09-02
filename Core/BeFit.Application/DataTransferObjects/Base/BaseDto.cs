namespace BeFit.Application.DataTransferObjects
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
    }
}

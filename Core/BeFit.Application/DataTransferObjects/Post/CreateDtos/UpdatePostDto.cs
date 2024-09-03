namespace BeFit.Application.DataTransferObjects
{
    public class UpdatePostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public UserDto User { get; set; } = null!;
    }
}

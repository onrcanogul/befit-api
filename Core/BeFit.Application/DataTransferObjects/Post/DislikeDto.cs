namespace BeFit.Application.DataTransferObjects
{
    public class DislikeDto
    {
        public string UserId { get; set; } = null!;
        public UserDto User { get; set; } = null!;
    }
}

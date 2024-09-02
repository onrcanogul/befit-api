namespace BeFit.Application.DataTransferObjects
{
    public class LikeDto : BaseDto
    {
        public string UserId { get; set; } = null!;
        public UserDto User { get; set; } = null!;
    }
}

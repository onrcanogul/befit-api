namespace BeFit.Application.DataTransferObjects.Post.CreateDtos
{
    public class CreatePostDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public UserDto User { get; set; } = null!;
        public List<PostImageDto> Images { get; set; } = new();
    }
}

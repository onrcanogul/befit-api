using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace BeFit.Application.DataTransferObjects.Post.CreateDtos
{
    public class CreatePostDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public IFormFileCollection Images { get; set; }
    }
}

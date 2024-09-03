using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.DataTransferObjects.Post.CreateDtos;

namespace BeFit.Application.Services.Post
{
    public interface IPostService
    {
        Task<ServiceResponse<List<PostDto>>> Get(int page, int size);
        Task<ServiceResponse<PostDto>> GetById(Guid id);
        Task<ServiceResponse<List<PostDto>>> GetByUser(string id);
        Task<ServiceResponse<NoContent>> Create(CreatePostDto model);
        Task<ServiceResponse<NoContent>> Update(UpdatePostDto model);
        Task<ServiceResponse<NoContent>> Delete(Guid id);
    }
}

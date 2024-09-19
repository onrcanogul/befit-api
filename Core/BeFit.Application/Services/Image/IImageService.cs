using Microsoft.AspNetCore.Http;

namespace BeFit.Application.Services.Image;

public interface IImageService<T> where T : Domain.Entities.Image
{
    public Task<ServiceResponse<List<PostImageDto>>> Get();
    public Task<ServiceResponse<NoContent>> Upload(IFormFileCollection files, Guid id, string path); 
    public Task<ServiceResponse<NoContent>> Delete(Guid id);    

}
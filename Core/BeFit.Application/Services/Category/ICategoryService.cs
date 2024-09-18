using BeFit.Application.DataTransferObjects.Create;
using BeFit.Application.DataTransferObjects.Update;

namespace BeFit.Application.Services.Category
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<CategoryDto>>> Get();
        Task<ServiceResponse<CategoryDto>> GetById(Guid id);
        Task<ServiceResponse<NoContent>> Create(CreateCategoryDto model);
        Task<ServiceResponse<NoContent>> Update(UpdateCategoryDto model);
        Task<ServiceResponse<NoContent>> Delete(Guid id);
    }
}

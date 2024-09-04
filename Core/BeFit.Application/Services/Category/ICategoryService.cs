using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;

namespace BeFit.Application.Services.Category
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<CategoryDto>>> Get();
        Task<ServiceResponse<CategoryDto>> GetById(Guid id);
        Task<ServiceResponse<NoContent>> Create(CategoryDto model);
        Task<ServiceResponse<NoContent>> Update(CategoryDto model);
        Task<ServiceResponse<NoContent>> Delete(Guid id);
    }
}

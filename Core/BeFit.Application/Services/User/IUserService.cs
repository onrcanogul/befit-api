using System.Linq.Expressions;
using BeFit.Domain.Entities.Identity;

namespace BeFit.Application.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<List<UserDto>>> Get();
        Task<ServiceResponse<UserDto>> GetById(string id);
        Task<ServiceResponse<List<UserDto>>> GetByCondition(Expression<Func<User, bool>> predicate);
        Task<ServiceResponse<NoContent>> Update(string id, string name, string surname, int age);
    }
}

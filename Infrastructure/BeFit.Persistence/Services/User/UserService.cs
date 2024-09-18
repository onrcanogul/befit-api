using System.Linq.Expressions;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.Services;
using BeFit.Domain.Entities.Identity;
using BeFit.Infrastructure.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services
{
    public class UserService(UserManager<User> userManager, IMapper mapper) : IUserService
    {
        public async Task<ServiceResponse<List<UserDto>>> Get()
        {
            var users = await UserQuery(userManager.Users).ToListAsync();
            var dto = mapper.Map<List<UserDto>>(users);
            return ServiceResponse<List<UserDto>>.Success(dto,StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<UserDto>> GetById(string id)
        {
            var user = await UserQuery(userManager.Users).FirstOrDefaultAsync(s => s.Id == id) ?? throw new NotFoundException("User not found"); 
            var dto = mapper.Map<UserDto>(user);
            return ServiceResponse<UserDto>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<List<UserDto>>> GetByCondition(Expression<Func<User, bool>> predicate)
        {
            var users = await UserQuery(userManager.Users).Where(predicate).ToListAsync();
            var dto = mapper.Map<List<UserDto>>(users);
            return ServiceResponse<List<UserDto>>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<NoContent>> Update(string id,string name, string surname, int age)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
                return ServiceResponse<NoContent>.Failure("User not found", StatusCodes.Status404NotFound);
            user.Name = name;
            user.Surname = surname;
            user.Age = age;
            var identityResult = await userManager.UpdateAsync(user);
            if(!identityResult.Succeeded)
                return ServiceResponse<NoContent>.Failure(identityResult.Errors.Select(e => e.Description).ToList(),
                    StatusCodes.Status500InternalServerError);
            return ServiceResponse<NoContent>.Success(StatusCodes.Status204NoContent);
        }
        private IQueryable<User> UserQuery(IQueryable<User> userQuery)
            => userQuery.Include(n => n.Comments)
                .Include(n => n.Properties)
                    .ThenInclude(ns => ns.NeededCarbohydrate)
                .Include(n => n.Properties)
                    .ThenInclude(ns => ns.NeededFat)
                .Include(n => n.Properties)
                    .ThenInclude(ns => ns.NeededProtein);
    }
}
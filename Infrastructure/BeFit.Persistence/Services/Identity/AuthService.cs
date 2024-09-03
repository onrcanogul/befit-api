using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.Services.Identity;
using BeFit.Domain.Entities;
using BeFit.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BeFit.Persistence.Services.Identity
{
    public class AuthService(UserManager<User> userManager) : IAuthService
    {
        public async Task<ServiceResponse<NoContent>> Login(LoginDto model)
        {
            User? user = await CheckUser(model.EmailOrUsername);
            if (user == null)
                return ServiceResponse<NoContent>.Failure("No record", StatusCodes.Status400BadRequest);

            var isLoggedIn = await userManager.CheckPasswordAsync(user, model.Password);

            if(isLoggedIn == false)
                return ServiceResponse<NoContent>.Failure("A problem while login", StatusCodes.Status500InternalServerError);

            return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
        }

        public async Task<ServiceResponse<NoContent>> Register(RegisterDto model)
        {
            if (model.Password != model.ConfirmPassword)
                return ServiceResponse<NoContent>.Failure("Passwords did not match", StatusCodes.Status400BadRequest);

            User user = new()
            {
                UserName = model.UserName,
                Email = model.Email,
                Gender = model.Gender,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return ServiceResponse<NoContent>.Failure(result.Errors.Select(x => x.Description).ToList(), StatusCodes.Status500InternalServerError);

            //token will added
            return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
        }


        private async Task<User> CheckUser(string emailOrUsername)
        {
            var user = await userManager.FindByEmailAsync(emailOrUsername);
            if (user == null)
                user = await userManager.FindByNameAsync(emailOrUsername);
            return user;
        }

        
    }
}

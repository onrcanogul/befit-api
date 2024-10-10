using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.Services.FoodBasket;
using BeFit.Application.Services.Identity;
using BeFit.Application.Services.Token;
using BeFit.Domain.Entities.Identity;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services.Identity
{
    public class AuthService(UserManager<User> userManager, ITokenHandler tokenHandler, IFoodBasketService foodBasketService) : IAuthService
    {
        public async Task<ServiceResponse<Token>> Login(LoginDto model)
        {
            var user = await CheckUser(model.EmailOrUsername);
            if (user == null) return ServiceResponse<Token>.Failure("No record", StatusCodes.Status400BadRequest);
            var isLoggedIn = await userManager.CheckPasswordAsync(user, model.Password);
            if (isLoggedIn == false) return ServiceResponse<Token>.Failure("A problem while login", StatusCodes.Status500InternalServerError);
            var token = tokenHandler.CreateToken(user);
            await UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 10);
            return ServiceResponse<Token>.Success(token,StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<NoContent>> Register(RegisterDto model)
        {
            if (model.Password != model.ConfirmPassword)
                return ServiceResponse<NoContent>.Failure("Passwords did not match", StatusCodes.Status400BadRequest);
            User user = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                Gender = model.Gender,
                Age = model.Age,
                Name = model.Name,
                Surname = model.Surname
            };
            var result = await userManager.CreateAsync(user, model.Password);
            
            await foodBasketService.Create(user.Id);
            
            return !result.Succeeded ? ServiceResponse<NoContent>.Failure(result.Errors.Select(x => x.Description).ToList(), StatusCodes.Status500InternalServerError) :
                ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
        }
        public async Task<ServiceResponse<Token>> LoginWithRefreshToken(string refreshToken)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            if (user == null) throw new NotFoundException("user not found");
            var token = tokenHandler.CreateToken(user);
            await UpdateRefreshTokenAsync(refreshToken, user, token.Expiration, 10);
            return ServiceResponse<Token>.Success(token, StatusCodes.Status200OK);
        }
        public async Task UpdateRefreshTokenAsync(string refreshToken, User user, DateTime accessTokenDate, int addToAccessToken)
        {
            if(user == null) throw new NotFoundException("user not found");
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiration = accessTokenDate.AddMinutes(addToAccessToken);
            await userManager.UpdateAsync(user);
        }
        private async Task<User?> CheckUser(string emailOrUsername)
        {
            var user = await userManager.FindByEmailAsync(emailOrUsername) ?? await userManager.FindByNameAsync(emailOrUsername);
            return user;
        }

        
    }
}

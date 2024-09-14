using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.Services.Token;
using BeFit.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BeFit.Infrastructure.Services
{
    public class TokenHandler(IConfiguration configuration) : ITokenHandler
    {
        public Token CreateToken(User user)
        {
            Token token = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]!));

            SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddMinutes(15);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: configuration["Token:Issuer"],
                audience: configuration["Token:Audience"],
                notBefore: DateTime.UtcNow,
                expires: token.Expiration,
                signingCredentials: signingCredentials,
                claims: new List<Claim>()
            );

            JwtSecurityTokenHandler handler = new();
            token.AccessToken = handler.WriteToken(jwtSecurityToken);
            token.RefreshToken = CreateRefreshToken();

            return token;
        }
        private static string CreateRefreshToken()
        {
            var number = new byte[32];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}

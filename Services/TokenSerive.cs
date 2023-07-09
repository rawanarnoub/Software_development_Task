using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApplication4.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = Encoding.UTF8.GetBytes(_configuration["Auth:secretKey"]);

            var symetricSecurityKey = new SymmetricSecurityKey(secretKey);

            var signingCredentials = new SigningCredentials(symetricSecurityKey, algorithm: SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Auth:issuer"],
                audience: _configuration["Auth:audience"],
                signingCredentials: signingCredentials,
                claims: claims,
                expires: DateTime.Now.AddMinutes(5));

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
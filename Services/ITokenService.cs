using System.Security.Claims;

namespace WebApplication4.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
    }
}

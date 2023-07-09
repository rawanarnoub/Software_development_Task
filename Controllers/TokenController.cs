using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public record LoginRequest(string UserName, string Email, string Role, string sub);
    public record AuthanticationResponse(string AccessToken);

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("token")]

        public IActionResult GenerateToken([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest is null)
            {
                return BadRequest("Invalid Request");
            }
         
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,loginRequest.UserName),
                new Claim(ClaimTypes.Email,loginRequest.Email),
                new Claim("Sub",loginRequest.sub) ,
                new Claim(ClaimTypes.Role,loginRequest.Role)
            };

            var token = _tokenService.GenerateAccessToken(claims);

            return Ok(new AuthanticationResponse(token));
        }

    }
}

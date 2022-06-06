using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Goal.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();

            if (AuthenticateUser(login) == true)
            {
                var tokenString = GenerateTokenJwt(login.Username, "admin");
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateTokenJwt(string username, string rolname)
        {
            //TODO: appsetting for Demo JWT - protect correctly this settings
            var secretKey = _config["Jwt:Key"];
            var audienceToken = _config["Jwt:Audience"];
            var issuerToken = _config["Jwt:Issuer"];
            var expireTime = _config["Jwt:Expire"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity 
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, rolname)
            });

            // create token to the user 
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }

        private bool AuthenticateUser(UserModel login)
        {
            //Demo Purpose  
            if (login.Username == "GoalSystems" && login.Password == "GoalSystems")
                return true;
            return false;
        }
    }

    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

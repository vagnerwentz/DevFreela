using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DevFreela.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly DateTime tokenExpiration = DateTime.Now.AddHours(1);

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJWTToken(string email, string role)
        {
            var key = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("userName", email),
                new Claim(ClaimTypes.Role, role),
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: tokenExpiration,
                signingCredentials: credentials,
                claims: claims
            );

            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

            return stringToken;
        }
    }
}


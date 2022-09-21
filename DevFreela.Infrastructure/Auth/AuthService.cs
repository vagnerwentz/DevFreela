using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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

        /// <summary>
        /// The ComputeSHA256Hash method will receive a string and return a hash
        /// </summary>
        /// <returns>Return a hashed password as string</returns>
        public string ComputeSHA256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}


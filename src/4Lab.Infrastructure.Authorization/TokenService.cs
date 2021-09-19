using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _4Lab.Infrastructure.Authorization
{
    public class TokenService
    {
        private static string _jwtSecretKey = ""; // TODO: PEGAR SECRET KEY

        public static string GenerateToken(int id, string name, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                            new Claim(ClaimTypes.Name, name),
                            new Claim(ClaimTypes.Role, role),
                            new Claim("UserId", id.ToString()),

                }),
                Expires = DateTime.UtcNow.AddHours(3),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

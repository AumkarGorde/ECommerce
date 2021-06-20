using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ecommerce.foundation
{
    public class TokenGenration
    {
        private string _userName { get; set; }
        private string _role { get; set; }
        public TokenGenration(string userName, string role)
        {
            _userName = userName;
            _role = role;
        }

        public string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(ApplicationConfigurations.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, _userName),
                    new Claim(ClaimTypes.Role, _role)
                }),
                Audience = "https://localhost:44345", // who or what the token intended for 
                Issuer = "https://localhost:44345",  // who created and signed this token
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

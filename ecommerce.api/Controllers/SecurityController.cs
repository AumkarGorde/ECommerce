using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ecommerce.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        public SecurityController()
        {

        }

        [HttpGet("{UserName}")]
        public ActionResult GenerateToken(string UserName)
        {
            string tokenResult = string.Empty;
            if (UserName == "Omkar")
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("651997651997651997"));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, "Omkar"),
                new Claim(JwtRegisteredClaimNames.Email, ""),
                new Claim("Role", "Admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken("newSearch",
                  "newSearch",
                  claims,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                 tokenResult = new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                tokenResult = "";
            }

            return Ok(tokenResult);
        }
    }
}

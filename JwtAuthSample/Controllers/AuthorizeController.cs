using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace JwtAuthSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {

        private JwtSettings _jwt;
        public AuthorizeController(IOptions<JwtSettings> jwts)
        {
            _jwt = jwts.Value;
        }
        public IActionResult Token(User user)
        {
            if (ModelState.IsValid)
            {
                if (!(user.account_name=="lurui"&&user.password=="123258"))
                {
                    return BadRequest();
                }
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,"lurui"),
                    new Claim(ClaimTypes.Role,"admin"),
                    new Claim("SuperAdmin","true")
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _jwt.Issuer,
                    _jwt.Audience,
                    claims,
                    DateTime.Now, 
                    DateTime.Now.AddMinutes(30),
                    creds);
                var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new {token= tokenStr });
            }
            return BadRequest();
        }
    }
}
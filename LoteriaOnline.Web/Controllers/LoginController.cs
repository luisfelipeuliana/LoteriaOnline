using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LoteriaOnline.ApplicationCore.Model.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LoteriaOnline.Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost, Route("api/login"), AllowAnonymous]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Usuário inválido");
            }

            if (usuario.Login == "admin" && usuario.Senha == "123456")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("LoteriaOnline@123"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Login),
                    new Claim(ClaimTypes.Role, "Operator")
                };

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

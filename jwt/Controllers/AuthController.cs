using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using jwt.Models.Application;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using jwt.Data;

namespace jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JWTDbDBContext _jWTDbDBContext;

        public AuthController(JWTDbDBContext jWTDbDBContext)
        {
            _jWTDbDBContext = jWTDbDBContext;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            if (user == null) return BadRequest("Invalid client request");

            var getUser = _jWTDbDBContext.Users.Where(r => r.Username == user.UserName && r.Password == user.Password);

            if (getUser.Count() == 0) return Unauthorized();

            var dbUser = getUser.FirstOrDefault();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TW9zaGVFcmV6UHJpdmF0ZUtleQ=="));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:44345",
                audience: "http://localhost:44345",
                claims: new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, dbUser.Id_user.ToString()),
                    new Claim(ClaimTypes.Name, dbUser.Username),
                    new Claim(ClaimTypes.SerialNumber, dbUser.GUID)
                },
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new { Token = tokenString });            
        }
    }
}
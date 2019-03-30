using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using jwt.Controllers.DTO;
using jwt.Models.DBContext;
using jwt.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly JWTDBContext _jWTDbDBContext;

        public UsersController(JWTDBContext jWTDbDBContext)
        {
            _jWTDbDBContext = jWTDbDBContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Controllers.DTO.User.Create postUser)
        {
            if (postUser == null) return BadRequest();
            if (String.IsNullOrEmpty(postUser.Username) || String.IsNullOrEmpty(postUser.Password)) return BadRequest();

            Models.DTO.User newUser = new Models.DTO.User()
            {
                Username = postUser.Username,
                Password = postUser.Password,
                GUID = Guid.NewGuid().ToString(),
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Id_state = 1
            };
            _jWTDbDBContext.Users.Add(newUser);
            _jWTDbDBContext.SaveChanges();

            return Ok("User Created");
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            var Users = _jWTDbDBContext.Users.Select(r => r.Username);
            return Ok(Users);
        }
    }
}
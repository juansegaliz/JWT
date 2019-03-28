using System;
using jwt.Data;
using jwt.Models.Database;
using jwt.Models.Application;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MongoData.Dao;

namespace jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly JWTDbDBContext _jWTDbDBContext;

        public UsersController(JWTDbDBContext jWTDbDBContext)
        {
            _jWTDbDBContext = jWTDbDBContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserModel.Create postUser)
        {
            if (postUser == null) return BadRequest();
            if (String.IsNullOrEmpty(postUser.Username) || String.IsNullOrEmpty(postUser.Password)) return BadRequest();

            Users newUser = new Users()
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
        public IActionResult Get()
        {
            var Users = _jWTDbDBContext.Users.Select(r => r.Username);
            return Ok(Users);
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetMongo()
        {
            AuthorizationDAO authorizationDAO = new AuthorizationDAO();
            var getAuthorizations = authorizationDAO.Read();
            return Ok(getAuthorizations);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using jwt.Controllers.DTO;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using jwt.Models.DBContext;
using MongoData.Controllers;

namespace jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JWTDBContext _jWTDbDBContext;
        private readonly AuthorizationController _authorizationController;

        public AuthController(JWTDBContext jWTDbDBContext)
        {
            _jWTDbDBContext = jWTDbDBContext;
            _authorizationController = new AuthorizationController();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody]Login user)
        {
            if (user == null) return BadRequest("Invalid client request");

            var getUser = _jWTDbDBContext.Users.Where(r => r.Username == user.Username && r.Password == user.Password);

            if (getUser.Count() == 0) return Unauthorized();

            var dbUser = getUser.FirstOrDefault();
            
            MongoData.Models.DTO.AuthorizationDTO authorization = new MongoData.Models.DTO.AuthorizationDTO
            {
                Id_user = dbUser.Id_user,
                Username = dbUser.Username,
                Role = dbUser.Role,
                GUID = dbUser.GUID,
                Id_state = dbUser.Id_state
            };

            string mongoAuthorizationDocumentId = _authorizationController.Create(authorization);

            var tokenString = Controllers.Classes.JWT.GetToken(dbUser.Id_user.ToString(), dbUser.Username, dbUser.GUID, mongoAuthorizationDocumentId);

            return Ok(new { Token = tokenString });            
        }
    }
}
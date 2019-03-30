using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoData.Controllers;

namespace jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoTestController : ControllerBase
    {
        private readonly AuthorizationController authorizationController;

        public MongoTestController()
        {
            authorizationController = new AuthorizationController();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Detele()
        {
            return Ok();
        }

    }
}
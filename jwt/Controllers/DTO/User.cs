using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwt.Controllers.DTO
{
    public class User
    {
        public class Create
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}

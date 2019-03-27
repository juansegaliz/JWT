using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwt.Models.Application
{
    public class UserModel
    {
        public class Create
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}

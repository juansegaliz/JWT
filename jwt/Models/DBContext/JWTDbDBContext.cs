using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using jwt.Models.DTO;

namespace jwt.Models.DBContext
{
    public class JWTDBContext : DbContext
    {
        public JWTDBContext(DbContextOptions<JWTDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}

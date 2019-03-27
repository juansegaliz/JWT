using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using jwt.Models.Database;

namespace jwt.Data
{
    public class JWTDbDBContext : DbContext
    {
        public JWTDbDBContext(DbContextOptions<JWTDbDBContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
    }
}

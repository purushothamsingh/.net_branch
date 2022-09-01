using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Concepts;
using Microsoft.EntityFrameworkCore;

namespace EF_Concepts
{
    public class ManagementContext : DbContext
    {

        public ManagementContext() { }
        public ManagementContext(DbContextOptions options):base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(@"Server=(.);Database=ManagementDB;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("server=.;database=ManagementDB;trusted_connection=true;");
        
    }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses    { get; set; }
    }
}

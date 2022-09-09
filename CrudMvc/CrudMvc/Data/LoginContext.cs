using CrudMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudMvc.Data
{
    public class LoginContext: DbContext 
    {

        public LoginContext() { }

        public LoginContext(DbContextOptions<LoginContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=(.);Database=ManagementDB;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("server=.;database=Bulky;trusted_connection=true;");
            //  optionsBuilder.UseSqlServer(connectionString: "MyConn");
        }
        public DbSet<Userstools> userstools { get; set; }


    }
}

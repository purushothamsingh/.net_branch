using CrudMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudMvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }


        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=(.);Database=ManagementDB;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("server=.;database=Bulky;trusted_connection=true;");
          //  optionsBuilder.UseSqlServer(connectionString: "MyConn");
        }
        DbSet<Category> Categories {get; set; }
    }
}

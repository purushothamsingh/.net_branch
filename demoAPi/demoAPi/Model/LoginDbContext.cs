using Microsoft.EntityFrameworkCore;

namespace demoAPi.Model
{
    public class LoginDbContext :DbContext
    {
        public LoginDbContext()
        {

        }
        public LoginDbContext(DbContextOptions<LoginDbContext> options):base(options)
        {

        }


        public DbSet<Login> logins { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace MultipleContextDemo.Models.Login
{
    public class LoginDbContext:DbContext
    {

        public LoginDbContext()
        {

        }

        public LoginDbContext(DbContextOptions<LoginDbContext> options): base(options)
        {
                
        }

        public DbSet<Login> logins { get; set; }



    }
}

using Microsoft.EntityFrameworkCore;

namespace MultipleContextDemo.Models.Register
{
    public class RegisterDbContext :DbContext
    {


        public RegisterDbContext()
        {
                
        }


        public RegisterDbContext(DbContextOptions<RegisterDbContext> options):base(options)
        {

        }

        public DbSet<Register> registers { get; set; }  
    }
}

using Microsoft.EntityFrameworkCore;

namespace JWT_AUTH.Models
{
    public class JWT_Context: DbContext
    {

        public JWT_Context(DbContextOptions<JWT_Context> options):base(options)
        {
                
        }

        public DbSet<Register> register { get; set; }
        public DbSet<Login> login { get; set; }

        public DbSet<Db_Registers> Db_Registers { get; set; }
    }

}

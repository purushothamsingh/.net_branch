using Microsoft.EntityFrameworkCore;
using MvcGroceryMangement.Models;

namespace MvcGroceryMangement.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> users { get; set; }
    }

}



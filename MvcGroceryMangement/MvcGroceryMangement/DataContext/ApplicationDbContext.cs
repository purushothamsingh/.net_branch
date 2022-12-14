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
        public DbSet<GroceryProducts> GroceryProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }

}



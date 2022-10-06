using Microsoft.EntityFrameworkCore;

namespace FileUpload.Models
{
    public class FileContext : DbContext
    {

        public FileContext(DbContextOptions<FileContext> options) : base(options) { }

        public DbSet<FileOnFileSystem> FileOnFileSystems { get; set; }

        public DbSet<FileOnDatabaseModel> FileOnDatabaseModels { get; set; }



    }
}

using Microsoft.EntityFrameworkCore;

namespace API_RepositoryPatternMethod.Models
{
    public class StudentContext:DbContext
    {

        public StudentContext(DbContextOptions<StudentContext> options): base(options) { }



        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

    }
}

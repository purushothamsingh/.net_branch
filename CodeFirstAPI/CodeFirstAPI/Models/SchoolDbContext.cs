using Microsoft.EntityFrameworkCore;

namespace CodeFirstAPI.Models
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.Studen_tId, sc.CourseId });
        }






        DbSet<Student> Students { get; set; }
       DbSet<Grade> Grades { get; set; }
        DbSet<Studen_t> Studen_Ts { get; set; }
        DbSet<Course> Courses { get; set; }

        DbSet<StudentCourse> StudentCourses { get; set; }

    }
}

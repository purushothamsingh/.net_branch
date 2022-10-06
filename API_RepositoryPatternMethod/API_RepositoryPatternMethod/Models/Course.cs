using System.ComponentModel.DataAnnotations.Schema;

namespace API_RepositoryPatternMethod.Models
{
    public class Course
    {
        public int Id { get; set; } 
        public string CourseName { get; set; }

        public Student course { get; init; }

    }
}

namespace CodeFirstAPI.Models
{
    public class Studen_t
    {
        public int Studen_tId { get; set; }
        public string Name { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
    }
    public class StudentCourse
    {
        public int Studen_tId { get; set; }
        public Studen_t Studen_t { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}

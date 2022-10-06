using API_RepositoryPatternMethod.Models;

namespace API_RepositoryPatternMethod.IRepository
{
    public interface IRepositoryStudent
    {

        IEnumerable<Student> GetStudents(); 

        void AddStudent(Student std);

        void UpdateStudent(int id, Student std);

        Student? GetById (int id);
    }
}

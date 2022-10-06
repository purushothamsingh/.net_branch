using API_RepositoryPatternMethod.IRepository;
using API_RepositoryPatternMethod.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_RepositoryPatternMethod.Repository
{
    public class StudentRepository : IRepositoryStudent
    {

        private readonly StudentContext db;
    public StudentRepository(StudentContext _db)
        {
           db = _db;
        }

        public void AddStudent(Student std)
        {
           db.Add(std);
            db.SaveChanges();
        }

        public Student GetById(int id)
        {
           Student res = db.Students.Find(id);
            if (res != null)
            {
                return res;
            }
            return new Student();
        }

        public IEnumerable<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        public void UpdateStudent(int id, Student std)
        {
            //var res = db.Students.Find(id);
            //if(res != null)
            
               db.Students.Update(std);
                db.SaveChanges();
            
            
        }
    }
}

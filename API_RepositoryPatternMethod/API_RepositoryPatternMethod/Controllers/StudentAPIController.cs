using API_RepositoryPatternMethod.IRepository;
using API_RepositoryPatternMethod.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_RepositoryPatternMethod.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly IRepositoryStudent db;

        public StudentAPIController(IRepositoryStudent _db)
        {
            db = _db;
        }


        [HttpGet]

        public ActionResult GetStudentList()
        {
            return Ok(db.GetStudents());
        }

        [HttpPost]

        public ActionResult AddStudents(Student std)
        {
            db.AddStudent(std);

            return NoContent();
        }




        [HttpGet]
        [Route("Get{id}")]

        public ActionResult GetById(int id)
        {
            Student res = db.GetById(id);
            
            if (res.Id == 0)
            {
                return NoContent();
            }
            return Ok(res);
        }

        [HttpPut]
        public ActionResult Update(int id, Student std)
        {
            db.UpdateStudent(id, std);

            return NoContent();
        }
    }
}

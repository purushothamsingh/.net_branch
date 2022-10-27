using demoAPi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demoAPi.Controllers
{
    [Route("api/[controller]/anu")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginDbContext db;

        public LoginController(LoginDbContext _db)
        {
            db = _db; 
        }
        [HttpGet]

        public async Task<ActionResult> getalldetails()
        {
            var fetchdata = db.logins.ToList();

            return Ok(fetchdata);
        }
    }
}

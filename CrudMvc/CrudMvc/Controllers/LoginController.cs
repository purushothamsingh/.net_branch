using CrudMvc.Data;
using CrudMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
namespace CrudMvc.Controllers
{
    public class LoginController : Controller
    {

        LoginContext db = new LoginContext();

        public IActionResult Index()
        {
           
            using (var db =  new LoginContext())
            {
                return View();
            }
            
        }
        [HttpPost]
        [ActionName("Index")]
        public IActionResult Index_( Userstools obj )
        {
            HttpContext.Session.SetString("UserName", obj.Name);
          
            using (var db = new LoginContext ())
            {
                if (ModelState.IsValid)
                {

                    var obj1 = (from i in db.userstools where i.Name == obj.Name  &&  i.Password == obj.Password select i).SingleOrDefault(); 
                  if(obj1 != null)
                    {
                        return RedirectToAction("Index", "Category");
                    }
                }
                return RedirectToAction("Index","Login");
            }

        }
    }
}

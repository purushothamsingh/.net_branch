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
            
          
            using (var db = new LoginContext ())
            {
                if (ModelState.IsValid)
                { 
                    var obj1 = (from i in db.userstools where i.Name == obj.Name  &&  i.Password == obj.Password select i).SingleOrDefault();

                    if (obj.Name == obj.Password.ToString())
                    {
                        ModelState.AddModelError("CustomError", "Both are equal"); //custom error with key value pairs
                        ModelState.AddModelError("Name", "this is false"); //custom error display below label
                    }

                    if (obj1 != null)
                    { 

                        HttpContext.Session.SetString("UserName", obj.Name);
                        TempData["Success"] = "Logged in Sucessfully..";
                        return RedirectToAction("Index", "Category");
                    }
                }
                return RedirectToAction("Index","Login");
            }

        }
    }
}

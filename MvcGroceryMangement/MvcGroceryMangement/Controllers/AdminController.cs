using Microsoft.AspNetCore.Mvc;
using MvcGroceryMangement.DataContext;
using MvcGroceryMangement.Models;
using System.Dynamic;

namespace MvcGroceryMangement.Controllers
{
    public class AdminController : Controller
    {
        DynamicConnect obj = new DynamicConnect();
        public static ApplicationDbContext db;
        public AdminController(ApplicationDbContext _db)
        {
            db = _db;
        }


        public IActionResult Admin_Login()
        {

            DynamicConnect model = new DynamicConnect();
      
            //ViewBag.name = HttpContext.Session.GetString("UserName");
           // ViewBag.c= HttpContext.Session.GetString("Controller_c");
           
            return View(model);
        }

        [HttpPost]
        public IActionResult Admin_Login(DynamicConnect obj  )
        {

  


          
                var obj1 = (from i in db.Admins where i.Admin_UserName == obj.Admins.Admin_UserName && i.Admin_Password == obj.Admins.Admin_Password select i).SingleOrDefault();

                if (obj.Admins.Admin_UserName == obj.Admins.Admin_Password.ToString())
                {
                    ModelState.AddModelError("CustomError", "Both are equal"); //custom error with key value pairs
                  //  ModelState.AddModelError("Name", "this is false"); //custom error display below label
                }

                if (obj1 != null)
                {

                    HttpContext.Session.SetString("UserName", obj.Admins.Admin_UserName);
                    TempData["Success"] = "Logged in Sucessfully..";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "Invalid Credentials..";
                    return RedirectToAction("Admin_Login", "Admin");
                }
            
            return View();
        }



        public IActionResult Logout()
        {
            var res = db.Carts.ToList();
            foreach(var item in res)
            {
                db.Remove(item);
                db.SaveChanges();
            }


            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }

    }
}

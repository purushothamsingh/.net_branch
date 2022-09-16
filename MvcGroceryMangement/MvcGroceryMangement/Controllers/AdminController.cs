using Microsoft.AspNetCore.Mvc;
using MvcGroceryMangement.DataContext;
using MvcGroceryMangement.Models;

namespace MvcGroceryMangement.Controllers
{
    public class AdminController : Controller
    {

        public static ApplicationDbContext db;
        public AdminController(ApplicationDbContext _db)
        {
            db = _db;
        }


        public IActionResult Admin_Login()
        {
            ViewBag.name = HttpContext.Session.GetString("UserName");
           // ViewBag.c= HttpContext.Session.GetString("Controller_c");
           
            return View();
        }

        [HttpPost]
        public IActionResult Admin_Login(Admin obj )
        {

            if (ModelState.IsValid)
            {
                var obj1 = (from i in db.Admins where i.Admin_UserName == obj.Admin_UserName && i.Admin_Password == obj.Admin_Password select i).SingleOrDefault();

                if (obj.Admin_UserName == obj.Admin_Password.ToString())
                {
                    ModelState.AddModelError("CustomError", "Both are equal"); //custom error with key value pairs
                  //  ModelState.AddModelError("Name", "this is false"); //custom error display below label
                }

                if (obj1 != null)
                {

                    HttpContext.Session.SetString("UserName", obj.Admin_UserName);
                    TempData["Success"] = "Logged in Sucessfully..";
                    return RedirectToAction("Create", "User");
                }
                else
                {
                    TempData["Error"] = "Invalid Credentials..";
                    return RedirectToAction("Admin_Login", "Admin");
                }
            }
            return View();
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }

    }
}

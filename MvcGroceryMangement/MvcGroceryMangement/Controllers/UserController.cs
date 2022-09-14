using Microsoft.AspNetCore.Mvc;
using MvcGroceryMangement.DataContext;
using MvcGroceryMangement.Models;

namespace MvcGroceryMangement.Controllers
{
    public class UserController : Controller
    {

        public static ApplicationDbContext db;
        public UserController(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IActionResult Create()
        {

            var result = db.users.ToList();
            return View(result);
        }


        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        [ActionName("AddUser")]
        public IActionResult AddUser(User obj)
        {


            if (ModelState.IsValid)
            {
                db.users.Add(obj);
                db.SaveChanges();
                TempData["Success"] = "User Added Sucessfully...";
                return RedirectToAction("Create", "User");  // action - controller 
            }
            return View(obj);
       
        }



        public IActionResult DeleteUser(int ? id)
        {
            var obj = db.users.Find(id);
            return View(obj);
        }
        [HttpPost]

        public IActionResult Delete(int? id)
        {
            var obj = db.users.Find(id);
            db.users.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Create", "User");
        }


    }
}

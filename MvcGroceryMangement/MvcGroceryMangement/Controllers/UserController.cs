using Microsoft.AspNetCore.Mvc;
using MvcGroceryMangement.DataContext;
using MvcGroceryMangement.Models;
using PagedList;
using PagedList.Mvc;

namespace MvcGroceryMangement.Controllers
{
    public class UserController : Controller
    {

        public static ApplicationDbContext db;
        public UserController(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IActionResult Create(int page = 1)
        {

            List<User> users = db.users.ToList();
            const int pageNum = 5
                ;
            if (page < 1)
            {
                page = 1;
            }
            int res = users.Count();
            var pager =  new ApplyPagination(res,page,pageNum);
            int pageSkip = (page - 1) * pageNum;
            var data = users.Skip(pageSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
          return  View(data);

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

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = db.users.Find(id);
            return View(obj);
            
        }

        [HttpPost]

        public IActionResult Edit(User obj)
        {
           
                if (ModelState.IsValid)
                {
                    db.users.Update(obj);
                    db.SaveChanges();
                    TempData["Success"] = "Action Changed Sucessfully...";
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





        public IActionResult User_Login()
        {
            HttpContext.Session.SetString("Controller_c", "User");
            TempData["c"] = "User";
            return RedirectToAction("Admin_Login", "Admin");
        }

        [HttpPost]
        public IActionResult User_Login(User obj)
        {

            if (ModelState.IsValid)
            {
                var obj1 = (from i in db.users where i.UserName == obj.UserName && i.Password == obj.Password select i).SingleOrDefault();

                if (obj.UserName == obj.Password.ToString())
                {
                    ModelState.AddModelError("CustomError", "Both are equal"); //custom error with key value pairs
                                                                               //  ModelState.AddModelError("Name", "this is false"); //custom error display below label
                }

                if (obj1 != null)
                {

                    HttpContext.Session.SetString("UserName", obj.UserName);
                    TempData["Success"] = "Logged in Sucessfully..";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "Invalid Credentials..";
                    return RedirectToAction("User_Login", "User");
                }
            }
            return View();
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }


        public IActionResult AddItem()
        {
            db.GroceryProducts.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(GroceryProducts obj)
        {
            if (ModelState.IsValid)
            {
                db.GroceryProducts.Add(obj);
                db.SaveChanges();
                TempData["Success"] = "Item Added Sucessfully...";
                return RedirectToAction("Index", "Home");  // action - controller 
            }
            return View(obj);
        }
}


}


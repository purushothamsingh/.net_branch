using CrudMvc.Data;
using CrudMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CrudMvc.Controllers
{
    public class CategoryController : Controller
    {


       

       public static ApplicationDbContext db =  new ApplicationDbContext();

        public IActionResult Index()
        {

            ViewBag.name = HttpContext.Session.GetString("UserName");
            using (var db = new ApplicationDbContext())
            {
               var ob =  db.Categories.ToList();
                return View(ob);
            }

        }

        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]

        public IActionResult Create(Category obj)
        {
           using(var db = new ApplicationDbContext())
            {
                if(obj.Name == obj.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("CustomError", "Both are equal"); //custom error with key value pairs
                    ModelState.AddModelError("Name", "this is false"); //custom error display below label
                }


                if (ModelState.IsValid)
                {
                    db.Categories.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Category");  // action - controller 
                }
              return View(obj);
            }
        }



        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            using(var db = new ApplicationDbContext())
            {
                var obj = db.Categories.Find(id);
                return View(obj);
            }
        }

        [HttpPost]

        public IActionResult Edit(Category obj)
        {
            using (var db = new ApplicationDbContext())
            {
                if (obj.Name == obj.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("CustomError", "Both are equal"); //custom error with key value pairs
                    ModelState.AddModelError("Name", "this is false"); //custom error display below label
                }


                if (ModelState.IsValid)
                {
                    db.Categories.Update(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Category");  // action - controller 
                }
                return View(obj);
            }
        }


     
    }

   




}

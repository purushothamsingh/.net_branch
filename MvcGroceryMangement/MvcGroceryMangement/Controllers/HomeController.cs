using Microsoft.AspNetCore.Mvc;
using MvcGroceryMangement.DataContext;
using MvcGroceryMangement.Models;
using System.Diagnostics;

namespace MvcGroceryMangement.Controllers
{
    public class HomeController : Controller
    {
       
        public static ApplicationDbContext db;
        public HomeController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            TempData["cval"] = 0;
            var res = db.GroceryProducts.ToList();
            return View(res);
        }

        [HttpPost]

        public IActionResult Index(GroceryProducts id)
        {
         
            var res = db.GroceryProducts.Find(id);

            if (ModelState.IsValid)
            {var r =  db.GroceryProducts.Find(id);
               
                if (res != null)
                {

          
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

        public IActionResult Cart(int? id ,GroceryProducts s)
        {
            
            var r = db.GroceryProducts.Find(id);

            if (ModelState.IsValid)
            {
                var res = db.GroceryProducts.Find(id);     
                if (res != null)
                {
                    var projects = db.GroceryProducts.Where(x => x.Id == id)
                                        .Select(x => new Cart
                                        {     
                                            //important
                                           ProductTitle=x.ProductTitle,
                                            Price = x.Price,
                                            ProductDesc =x.ProductDesc,
                                        }).ToList();

                   foreach(var item in projects)
                    {
                        db.Carts.Add(item);
                        db.SaveChanges();
                    }


                    TempData["Success"] = "Added to cart  Sucessfully..";
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    TempData["Error"] = "Failed Credentials..";
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
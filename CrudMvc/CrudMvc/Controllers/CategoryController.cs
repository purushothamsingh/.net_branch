using CrudMvc.Data;
using CrudMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudMvc.Controllers
{
    public class CategoryController : Controller
    {

       public static ApplicationDbContext db =  new ApplicationDbContext();

        public IActionResult Index()
        {

            
            using (var db = new ApplicationDbContext())
            {
               var ob =  db.Categories.ToList();
                return View(ob);
            }

        }
           



    }
}

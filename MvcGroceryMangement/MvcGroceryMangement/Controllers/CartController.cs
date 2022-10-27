using Microsoft.AspNetCore.Mvc;
using MvcGroceryMangement.DataContext;
using MvcGroceryMangement.Models;


namespace MvcGroceryMangement.Controllers
{
    public class CartController : Controller
    {
        public static ApplicationDbContext db;
        public CartController(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IActionResult CartView(int  page = 1)
        {
            List<Cart> carts = db.Carts.ToList();
            const int pageNum = 7
                ;
            if (page < 1)
            {
                page = 1;
            }
            int res = carts.Count();
            var pager = new ApplyPagination(res, page, pageNum);
            int pageSkip = (page - 1) * pageNum;
            var data = carts.Skip(pageSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            return View(data);
        }

        public IActionResult RemoveItem(int? id)
        {
            var obj = db.Carts.Find(id);
            return View(obj);
        }
        [HttpPost]
        [ActionName("RemoveItem")]
        public IActionResult RemoveItems(int? id)
        {
            var obj = db.Carts.Find(id);
            db.Carts.Remove(obj);
            db.SaveChanges();
            TempData["error"] = "Item Removed Succesfully";
            return RedirectToAction("CartView", "Cart");
        }

       
       

    }
}

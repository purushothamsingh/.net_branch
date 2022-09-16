using Microsoft.AspNetCore.Mvc;

namespace MvcGroceryMangement.Controllers
{
    public class GroceryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

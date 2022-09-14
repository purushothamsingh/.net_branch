using Microsoft.AspNetCore.Mvc;

namespace MvcGroceryMangement.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

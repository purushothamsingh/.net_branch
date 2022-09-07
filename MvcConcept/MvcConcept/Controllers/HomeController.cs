using Microsoft.AspNetCore.Mvc;
using MvcConcept.Models;
using System.Diagnostics;

namespace MvcConcept.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["name"]= "Purushotham Singh";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Sample()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
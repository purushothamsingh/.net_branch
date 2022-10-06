using Microsoft.AspNetCore.Mvc;
using OtpVerfication_FireBase.Models;
using System.Diagnostics;

namespace OtpVerfication_FireBase.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
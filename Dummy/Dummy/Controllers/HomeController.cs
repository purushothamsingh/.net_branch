using Dummy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dummy.Controllers
{
    public class HomeController : Controller
    {
        private readonly string rd =
              Path.Combine(Directory.GetCurrentDirectory(),"wwwroot");

        public IActionResult Index()
        {
            List<string> pdf = Directory.GetFiles(rd, "*.pdf").Select(Path.GetFileName).ToList();

            if(pdf.Count >0)
            {
                return View(pdf);
            }
            return View();
            
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {

            if(file != null)
            {
                var path = Path.Combine(
                    rd,DateTime.Now.Ticks.ToString() + Path.GetExtension(file.FileName)
                    );

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return View();
        }
        public async Task<IActionResult> Download(string filepath)
        {

          var path =  Path.Combine(Directory.GetCurrentDirectory(),"wwwroot",filepath);
            var memory = new MemoryStream();
            using(var strem =  new FileStream(path, FileMode.Open))
            {
                await strem.CopyToAsync(memory);
            }
            memory.Position = 0;
            var contenttype = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(path);
            return File(memory, contenttype, fileName);
        }


    }
}
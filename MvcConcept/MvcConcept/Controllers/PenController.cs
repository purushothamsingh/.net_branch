using Microsoft.AspNetCore.Mvc;
using MvcConcept.Models;

namespace MvcConcept.Controllers
{
    public class PenController : Controller
    {

        public static List<Pen> pens = Pen.getAllPens();
        public static Pen p = new Pen();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PenDetails()
        {
            return View(pens);
        }
        [HttpPost]
        public IActionResult AddPen(Pen p)
        {
            pens.Add(p);
            return RedirectToAction("PenDetails");
        }
        public IActionResult AddPen()
        {
            
            return View();
        }

         public IActionResult Details(int id)
        {
            p = pens.Where(x => x.Id == id).SingleOrDefault();
            return View(p);
           
        }
        
        public IActionResult Edit(int id)
        {
            var pen = pens.Where(x => x.Id == id).SingleOrDefault();
            
            return View(pen);
        }
        [HttpPost]
        public IActionResult Edit(Pen p)
        {
            
            Pen oldpen = pens.Where(pens => pens.Id == p.Id).SingleOrDefault();
            //oldpen.PenName = p.PenName;
            //oldpen.Price = p.Price;
            pens.Remove(oldpen);
            pens.Add(p);
            return RedirectToAction("PenDetails");
        }
        public IActionResult Delete(int id)
        {
           var pen1 =  pens.Where(x=> x.Id == id).SingleOrDefault();    
            //pens.Remove(pen1);
            return View(pen1);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            p = pens.Where(pens => pens.Id == id).SingleOrDefault();
            pens.Remove(p);
            return RedirectToAction("Pendetails");
        }
    }
}

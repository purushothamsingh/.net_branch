using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAPIConcept.Models;

namespace WebAPIConcept.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryController : ControllerBase
    {

        private readonly SampleGroceryContext db;

        public GroceryController(SampleGroceryContext _db)
        {
           db = _db;
        }


        [HttpGet]

        public async Task<ActionResult<IEnumerable<SampleGroceryContext>>> getproducts()
        {
           //    var res =  db.Groceries.Include(x=>x.User);
            var result = db.Groceries.ToListAsync();
            return Ok(await result);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Grocery g)
        {
            if (g == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                db.Groceries.Add(g);
                await db.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet]
        [Route("getbyid{id}")]

        public async Task<ActionResult> GetbyID(int id)
        {
            Grocery g= await db.Groceries.FindAsync(id);
            return Ok(g);
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id , Grocery g)
        {

            if(id == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                db.Groceries.Update(g);
         
                await db.SaveChangesAsync();
            }
            return Ok();
        }





    }
}

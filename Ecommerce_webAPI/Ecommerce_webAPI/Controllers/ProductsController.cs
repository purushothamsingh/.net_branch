using Ecommerce_webAPI.Models;
using Ecommerce_webAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ecommerce_webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly Context db;
        public ProductsController(Context _db)
        {
            db = _db;  
        }


        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> Getproducts()
        {
            return await db.Products.ToListAsync();
        }

        [HttpGet("{id:int}")] //check contrain for id to be integer
        public ActionResult<List<Product>> GetProducts(int id)
        {
            List<Product> product = new List<Product>
            {
               new Product{Id=id,Myproperty="dd"},
               new Product{Id=id,Myproperty="ddp"}
         };
            return Ok(product);
        }
    }
}

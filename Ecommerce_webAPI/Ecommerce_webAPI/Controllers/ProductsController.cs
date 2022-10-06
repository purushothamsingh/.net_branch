using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        [HttpGet]

        public string Getproducts()
        {
            return "list of products";
        }

        [HttpGet("{id:int}")] //check contrain for id to be integer
        public string Getproduct(int id)
        {
            return "single product";
        }
    }
}

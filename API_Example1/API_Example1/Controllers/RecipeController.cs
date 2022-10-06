using API_Example1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Example1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {

        [HttpGet]

        public string[] GetDishes()
        {
            string[] dishes = { "fish", "mutton", "chicken", "prawn", "egg" };
            return dishes;
        }

        [HttpGet]
        [Route("action")]
       public ActionResult GetDishe([FromQuery] int count) // [fromquer,frombody] binding to httprequest
            {
                string[] dishes = { "fish", "mutton", "chicken", "prawn", "egg" };
                return Ok(dishes.Take(count));
            }

        //using model

        [HttpGet]
        [Route("model")]

        public ActionResult GetRecipes([FromQuery] int count)
        {
            Recipe[] recipes = {
            new () {Title = "banana curry", Description = "hello banana"},
             new () {Title = "mutton curry", Description = "hello mutton"},
            new () {Title ="egg curry",Description="hello egg" }
            
            }; 
            

            return Ok(recipes.Take(count));
        }


        [HttpPost]
        [Route("model")]
        public ActionResult AddRecipe([FromBody] Recipe newRecipe)
        {

            
            return Created("", newRecipe);


        }
    }
}


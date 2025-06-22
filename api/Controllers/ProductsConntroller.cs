using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsConntroller : ControllerBase
    {

        [HttpGet("{id:int}")]
        public ActionResult<Product> get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid product ID.");
            }
            // Simulate fetching a product from a database
            var product = new Product { Id = id, Name = "Sample Product" };
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            return Ok(product);

        }
    }



    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    }

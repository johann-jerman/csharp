using API.DTO.Product;
using API.Service.Product;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace TuProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _ProductServive;

        public ProductController(ProductService productService)
        {
            _ProductServive = productService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ProductServive.Get());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_ProductServive.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDTO product)
        {
            Console.WriteLine(product);
            return Ok(_ProductServive.Create(product));
        }

        [HttpPut("{id}")]
        public IActionResult Upadate(int id, [FromBody] Products product) 
        {
            return Ok(_ProductServive.Update(product, id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id) 
        {
            _ProductServive.Delete(id);
            return NoContent();
        }
    }
}

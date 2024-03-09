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
            try
            {
                return Ok(_ProductServive.Get());
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_ProductServive.GetById(id));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDTO product)
        {
            try
            {
                return Ok(_ProductServive.Create(product));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("{id}")]
        public IActionResult Upadate(int id, [FromBody] ProductDTO product) 
        {
            try
            {
                return Ok(_ProductServive.Update(product, id));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id) 
        {
            try
            {
                _ProductServive.Delete(id);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
            return NoContent();
        }
    }
}

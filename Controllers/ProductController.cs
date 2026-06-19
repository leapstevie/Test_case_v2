using Microsoft.AspNetCore.Mvc;
using SV35.POS.Service;

namespace SV35.POS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _productService.GetAllProductsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _productService.GetProductByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post(Models.Product product)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.AddProductAsync(product);
                if (result == "Created")
                {
                    return Created("", product);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Models.Product product)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.UpdateProductAsync(product);
                if (result == "Not found")
                {
                    return NotFound(result);
                }
                if (result == "Updated")
                {
                    return Ok(result);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (result == "Not found")
            {
                return NotFound(result);
            }
            if (result == "Deleted")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
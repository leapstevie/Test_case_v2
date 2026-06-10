using Microsoft.AspNetCore.Mvc;
using SV35.POS.Service;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SV35.POS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _categoryService.GetAllCategoriesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _categoryService.GetCategoryByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post(Models.Category category)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.AddCategoryAsync(category);
                if (result == "Added")
                {
                    return Created("", result);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Models.Category category)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.UpdateCategoryAsync(category);
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
            var result = await _categoryService.DeleteCategoryAsync(id);
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
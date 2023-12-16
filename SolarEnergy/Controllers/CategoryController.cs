using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarEnergy.Services;
using SolarEnergy.ViewModel;

namespace SolarEnergy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Add(CategoryVM category)
        {
            var newCategory = new Category()
            {
              // Id = category.Id,
               Name = category.Name,
            };
            await _categoryRepository.AddAsync(newCategory);
            return Ok(newCategory);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> Update(Category category, int id)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.Id = category.Id;
            existingCategory.Name = category.Name;
            await _categoryRepository.UpdateAsync(existingCategory);
            return Ok(existingCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> Delete(int id)
        {
            var category = await _categoryRepository.DeleteAsync(id);
            return Ok("has deletd");
        }
    }

}


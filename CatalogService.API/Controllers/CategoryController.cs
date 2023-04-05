using CatalogService.Application.Interfaces;
using CatalogService.Core;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetCategoryAsync")]
        public async Task<ActionResult<Category>> GetAsync(int categoryId)
        {
            var category = _unitOfWork.Categories.GetAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            return new ObjectResult(category);
        }

        [HttpGet("GetAllCategoriesAsync")]
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            _logger.LogInformation("All companies fetched from the database");

            return categories;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddAsync(Category category)
        {
            if (category == null)
            {
                
                return BadRequest(string.Empty);
            }

            await _unitOfWork.Categories.AddAsync(category);
            _logger.LogInformation($"New category added: {category.Name}");

            return Ok(category);
        }

        [HttpPut]
        public async Task<ActionResult<Category>> UpdateAsync(Category category) 
        {
            if (category == null)
            {
                _logger.LogError("There is no category to update");
                return BadRequest(string.Empty);
            }
            if (!_unitOfWork.Categories.Any(category.Id))
            {
                _logger.LogInformation("The category for updating was not found in the Database");
                return NotFound();
            }

            await _unitOfWork.Categories.UpdateAsync(category);
            _logger.LogInformation($"New category added: {category.Name}");

            return Ok(category);
        }

        [HttpDelete]
        public async Task<ActionResult<Category>> DeleteAsync(int id)
        {
            Category category = _unitOfWork.Categories.Get(id);
            if(category == null)
            {
                _logger.LogInformation("The category to delete was not found");
                return NotFound();
            }

            await _unitOfWork.Categories.DeleteAsync(id);

            return Ok(category);
        }
    }
}
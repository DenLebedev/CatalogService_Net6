using AutoMapper;
using CatalogService.Application.Interfaces;
using CatalogService.Application.ViewModels;
using CatalogService.Core;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IMapper mapper, ILogger<CategoryController> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("/categories/{categoryId}", Name = "GetCategoryById")]
        public async Task<ActionResult<Category>> GetAsync(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            return new ObjectResult(category);
        }

        [HttpGet("/categories", Name = "GetAllCategories")]
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            _logger.LogInformation("All companies fetched from the database");

            return categories;
        }

        [HttpPost("/categories", Name = "AddCategory")]
        public async Task<ActionResult<Category>> AddAsync(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel == null)
            {
                return BadRequest(string.Empty);
            }

            Category category = _mapper.Map<Category>(categoryViewModel);

            await _unitOfWork.Categories.AddAsync(category);
            _logger.LogInformation($"New category added: {category.Name}");

            return Ok(category);
        }

        [HttpPut("/categories", Name = "UpdateCategory")]
        public async Task<ActionResult<Category>> UpdateAsync(CategoryUpdateViewModel updateViewModel) 
        {
            if (updateViewModel == null)
            {
                _logger.LogError("There is no category to update");
                return BadRequest(string.Empty);
            }

            Category category = _mapper.Map<Category>(updateViewModel);
            if (!_unitOfWork.Categories.Any(category.Id))
            {
                _logger.LogInformation("The category for updating was not found in the Database");
                return NotFound();
            }

            await _unitOfWork.Categories.UpdateAsync(category);
            _logger.LogInformation($"Category - {category.Name} updated.");

            return Ok(category);
        }

        [HttpDelete("/categories", Name = "DeleteCategory")]
        public async Task<ActionResult<Category>> DeleteAsync(int id)
        {
            Category category = await _unitOfWork.Categories.GetAsync(id);
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
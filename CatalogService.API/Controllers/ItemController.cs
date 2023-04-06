using AutoMapper;
using CatalogService.Application.Interfaces;
using CatalogService.Application.Parameters;
using CatalogService.Application.ViewModels;
using CatalogService.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CatalogService.API.Controllers
{
    public class ItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ItemController> _logger;

        public ItemController(IMapper mapper, ILogger<ItemController> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("/items/{itemId}", Name = "GetItemById")]
        public async Task<ActionResult<Item>> GetAsync(int itemId)
        {
            var item = await _unitOfWork.Items.GetAsync(itemId);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpGet("~/itemspaginator", Name = "GetAllItemsPaginator")]
        public async Task<PagedList<Item>> GetAllAsync([FromQuery] ItemParameters itemParameters)
        {
            var item = await _unitOfWork.Items.GetAllAsync(itemParameters);
            var metadata = new
            {
                item.TotalCount,
                item.PageSize,
                item.CurrentPage,
                item.TotalPages,
                item.HasNext,
                item.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            _logger.LogInformation("All companies fetched from the database");

            return item;
        }

        [HttpGet("/items", Name = "GetAllItems")]
        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var item = await _unitOfWork.Items.GetAllAsync();
            _logger.LogInformation("All companies fetched from the database");

            return item;
        }

        [HttpPost("/items", Name = "AddItem")]
        public async Task<ActionResult<Item>> AddAsync(ItemViewModel itemViewModel)
        {
            if (itemViewModel == null)
            {
                return BadRequest(string.Empty);
            }

            Item item = _mapper.Map<Item>(itemViewModel);

            await _unitOfWork.Items.AddAsync(item);
            _logger.LogInformation($"New category added: {item.Name}");

            return Ok(item);
        }

        [HttpPut("/items", Name = "UpdateItem")]
        public async Task<ActionResult<Item>> UpdateAsync(ItemUpdateViewModel updateViewModel)
        {
            if (updateViewModel == null)
            {
                _logger.LogError("There is no category to update");
                return BadRequest(string.Empty);
            }

            Item item = _mapper.Map<Item>(updateViewModel);
            if (!_unitOfWork.Items.Any(item.Id))
            {
                _logger.LogInformation("The category for updating was not found in the Database");
                return NotFound();
            }

            await _unitOfWork.Items.UpdateAsync(item);
            _logger.LogInformation($"Item - {item.Name} updated.");

            return Ok(item);
        }

        [HttpDelete("/items", Name = "DeleteItem")]
        public async Task<ActionResult<Item>> DeleteAsync(int id)
        {
            Item item = await _unitOfWork.Items.GetAsync(id);
            if (item == null)
            {
                _logger.LogInformation("The category to delete was not found");
                return NotFound();
            }

            await _unitOfWork.Items.DeleteAsync(id);

            return Ok(item);
        }
    }
}

using CatalogService.Application.Interfaces;
using CatalogService.Core;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogServiceController : ControllerBase
    {
        private readonly ICatalogService _service;
        private readonly ILogger<CatalogServiceController> _logger;

        public CatalogServiceController(ILogger<CatalogServiceController> logger, ICatalogService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Item> Get(int categoryId)
        {
            var result = _service.GetItemsInCategory(categoryId);

            return result;
        }
    }
}
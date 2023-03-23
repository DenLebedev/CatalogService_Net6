using CatalogService.Core;

namespace CatalogService.Application.Interfaces
{
    public interface ICatalogService
    {
        IEnumerable<Item> GetItemsInCategory(int categoryId);
    }
}

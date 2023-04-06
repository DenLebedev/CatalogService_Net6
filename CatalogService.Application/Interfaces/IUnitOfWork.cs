using CatalogService.Core;

namespace CatalogService.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<Category> Categories { get; }
        //IRepositoryBase<Item> Items { get; }
        IItemRepository Items { get; }
        void Save();
    }
}

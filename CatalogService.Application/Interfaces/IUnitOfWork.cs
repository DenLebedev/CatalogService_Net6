using CatalogService.Core;

namespace CatalogService.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Item> Items { get; }
        void Save();
    }
}

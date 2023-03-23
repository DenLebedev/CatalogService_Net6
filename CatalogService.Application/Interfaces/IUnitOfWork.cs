using CatalogService.Core;

namespace CatalogService.Application.Interfaces
{
    internal interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Item> Items { get; }
        void Save();
    }
}

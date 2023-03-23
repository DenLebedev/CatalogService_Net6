using CatalogService.Core;
using CatalogService.Application.Interfaces;
using CatalogService.Infrastructure.EF;

namespace CatalogService.Infrastructure.Repositories
{
    internal class EFUnitOfWork : IUnitOfWork
    {
        private CatalogServiceContext db;
        private CategoryRepository categoryRepository;
        private ItemRepository itemRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new CatalogServiceContext(connectionString);
        }
        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public IRepository<Item> Items
        {
            get
            {
                if (itemRepository == null)
                    itemRepository = new ItemRepository(db);
                return itemRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

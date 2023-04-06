using CatalogService.Core;
using CatalogService.Application.Interfaces;
using CatalogService.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private CatalogServiceContext db;
        private CategoryRepository categoryRepository;
        private ItemRepository itemRepository;

        public EFUnitOfWork(DbContextOptions<CatalogServiceContext> options)
        {
            db = new CatalogServiceContext(options);
        }
        public IRepositoryBase<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public IItemRepository Items
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

using CatalogService.Application.Interfaces;
using CatalogService.Core;
using CatalogService.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories
{
    internal class ItemRepository : IRepository<Item>
    {
        private CatalogServiceContext db;

        public ItemRepository(CatalogServiceContext context)
        {
            this.db = context;
        }

        public IEnumerable<Item> GetAll()
        {
            return db.Items;
        }

        public Item Get(int id)
        {

            return db.Items.Find(id);
        }

        public void Add(Item item)
        {
            db.Items.Add(item);
        }

        public void Update(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Item item = db.Items.Find(id);
            if (item != null)
                db.Items.Remove(item);
        }
    }
}

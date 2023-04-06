using CatalogService.Application.Interfaces;
using CatalogService.Core;
using CatalogService.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private CatalogServiceContext db;

        public ItemRepository(CatalogServiceContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Item>> GetAllAsync() =>
            await db.Items.ToListAsync();

        public async Task<Item> GetAsync(int id)
        {
            Item item = await db.Items.FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }

        public async Task AddAsync(Item item)
        {
            db.Items.Add(item);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Item item)
        {
            db.Items.Update(item);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Item item = db.Items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                db.Items.Remove(item);
            }

            await db.SaveChangesAsync();
        }

        public bool Any(int id)
        {
            return db.Items.Any(x => x.Id == id);
        }
    }
}

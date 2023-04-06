using CatalogService.Application.Interfaces;
using CatalogService.Application.Parameters;
using CatalogService.Core;
using CatalogService.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories
{
    public class ItemRepository : IRepositoryBase<Item>, IItemRepository
    {
        private CatalogServiceContext db;

        public ItemRepository(CatalogServiceContext context)
        {
            this.db = context;
        }

        public async Task<PagedList<Item>> GetAllAsync(ItemParameters itemParameters)
        {
            var items = await db.Items.ToListAsync();

            return PagedList<Item>.ToPagedList(
                items.OrderBy(on => on.Name).ToList(),
                itemParameters.PageNumber,
                itemParameters.PageSize);
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await db.Items.ToListAsync();
        }

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

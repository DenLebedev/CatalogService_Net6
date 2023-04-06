using CatalogService.Core;
using CatalogService.Application.Interfaces;
using CatalogService.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private CatalogServiceContext db;

        public CategoryRepository(CatalogServiceContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() =>
            await db.Categories.ToListAsync();


        public async Task<Category> GetAsync(int id)
        {
            Category category = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }

        public async Task AddAsync(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            db.Categories.Update(category);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) 
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == id);
            if (category != null)
            {
                db.Categories.Remove(category);
            }

            await db.SaveChangesAsync();
        }

        public bool Any(int id) 
        {
            return db.Categories.Any(x => x.Id == id);
        }
    }
}

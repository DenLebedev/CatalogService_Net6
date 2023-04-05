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

        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() =>
            await db.Categories.ToListAsync();

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public async Task<Category> GetAsync(int id)
        {
            Category category = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }

        public void Add(Category category)
        {
            db.Categories.Add(category);
        }

        public async Task AddAsync(Category category)
        {
            await db.Categories.AddAsync(category);
        }

        public void Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }

        public async Task UpdateAsync(Category category)
        {
            db.Categories.Update(category);
            await db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category != null)
            {
                db.Categories.Remove(category);
            }
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

using CatalogService.Core;
using CatalogService.Application.Interfaces;
using CatalogService.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories
{
    internal class CategoryRepository : IRepository<Category>
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

        public Category Get(int id)
        {

            return db.Categories.Find(id);
        }

        public void Add(Category category)
        {
            db.Categories.Add(category);
        }

        public void Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category != null)
                db.Categories.Remove(category);
        }
    }
}

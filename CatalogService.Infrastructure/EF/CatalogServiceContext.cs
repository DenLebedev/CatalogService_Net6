using CatalogService.Core;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.EF
{
    internal class CatalogServiceContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        public CatalogServiceContext(DbContextOptions<CatalogServiceContext> options)
            : base(options)
        {
        }
    }
}

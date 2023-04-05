using CatalogService.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CatalogService.Infrastructure.EF
{
    public class CatalogServiceContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        public CatalogServiceContext(DbContextOptions<CatalogServiceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasOne(p => p.Category)
                .WithMany(t => t.CategoryItems)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}

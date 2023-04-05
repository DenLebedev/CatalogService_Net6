using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Core
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal Price { get; set; }
        public uint Amount { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Core
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }
        public string? Image { get; set; }
        public int? ParentCategoryId { get; set; }
        public List<Item> CategoryItems { get; set; }
    }
}
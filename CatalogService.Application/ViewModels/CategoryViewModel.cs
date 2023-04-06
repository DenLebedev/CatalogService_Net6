using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.ViewModels
{
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}

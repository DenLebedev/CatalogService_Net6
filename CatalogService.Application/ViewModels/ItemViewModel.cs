using CatalogService.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.ViewModels
{
    public class ItemViewModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public uint Amount { get; set; }
    }
}

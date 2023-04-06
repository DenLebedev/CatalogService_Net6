using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Parameters
{
    public class ItemParameters :QueryItemParameters
    {
        public uint ItemsCategoryId { get; set; }
    }
}

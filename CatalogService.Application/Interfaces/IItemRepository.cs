using CatalogService.Application.Parameters;
using CatalogService.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Interfaces
{
    public interface IItemRepository :  IRepositoryBase<Item>
    {
        Task<PagedList<Item>> GetAllAsync(ItemParameters itemParameters);
    }
}

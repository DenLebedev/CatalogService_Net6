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
        Task<Item> GetAsync(int id);
        Task AddAsync(Item item);
        Task UpdateAsync(Item item);
        Task DeleteAsync(int id);
        bool Any(int id);
    }
}

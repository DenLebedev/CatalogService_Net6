using CatalogService.Application.Parameters;
using System.Runtime.InteropServices;

namespace CatalogService.Application.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        bool Any(int id);
    }
}

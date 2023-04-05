namespace CatalogService.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Get(int id);
        Task<T> GetAsync(int id);
        void Add(T item);
        Task AddAsync(T item);
        void Update(T item);
        Task UpdateAsync(T item);
        void Delete(int id);
        Task DeleteAsync(int id);
        bool Any(int id);
    }
}

namespace CatalogService.Application.Interfaces
{
    internal interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}

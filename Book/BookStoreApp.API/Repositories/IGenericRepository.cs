namespace BookStoreApp.API.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int? id);
        Task UpdateAsync(T entity);
        Task<bool> Exists(int id);
    }
}

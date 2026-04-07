namespace Kanban_board.Models.Interfaces
{
    public interface IRepository<T,K> where T : class
    {
        Task<T> GetByIdAsync(K id);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(K id);
    }
}

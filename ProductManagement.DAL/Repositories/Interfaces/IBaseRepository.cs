namespace ProductManagement.DAL.Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<T> AddAsync(T entity);

    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetByIdAsync(int id);

    T Update(T entity);
    T Delete(T entity);
}

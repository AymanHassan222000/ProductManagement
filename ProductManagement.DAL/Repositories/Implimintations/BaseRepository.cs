using Microsoft.EntityFrameworkCore;
using ProductManagement.DAL.Context;
using ProductManagement.DAL.Repositories.Interfaces;

namespace ProductManagement.DAL.Repositories.Implimintations;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public T Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return entity;
    }


    public T Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        return entity;
    }

}

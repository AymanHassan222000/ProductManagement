using ProductManagement.DAL.Context;
using ProductManagement.DAL.Models;
using ProductManagement.DAL.Repositories.Implimintations;
using ProductManagement.DAL.Repositories.Interfaces;
using ProductManagement.DAL.UnitOfWork.Interface;

namespace ProductManagement.DAL.UnitOfWork.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();


    private IBaseRepository<Product> _products;
    public IBaseRepository<Product> Products
    {
        get
        {
            if (_products is null)
                _products = new BaseRepository<Product>(_context);

            return _products;
        }
    }

    private IBaseRepository<Order> _orders;
    public IBaseRepository<Order> Orders
    {
        get
        {
            if (_orders is null)
                _orders = new BaseRepository<Order>(_context);

            return _orders;
        }
    }
}

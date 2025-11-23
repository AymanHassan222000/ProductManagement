using ProductManagement.DAL.Models;
using ProductManagement.DAL.Repositories.Interfaces;

namespace ProductManagement.DAL.UnitOfWork.Interface;

public interface IUnitOfWork: IDisposable
{
    IBaseRepository<Product> Products { get; }
    IBaseRepository<Order> Orders { get; }

    Task<int> CompleteAsync();
}

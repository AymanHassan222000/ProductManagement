using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.DAL.Context;
using ProductManagement.DAL.Repositories.Implimintations;
using ProductManagement.DAL.Repositories.Interfaces;
using ProductManagement.DAL.UnitOfWork.Implementation;
using ProductManagement.DAL.UnitOfWork.Interface;

namespace ProductManagement.DAL.Extensions
{
    public static class DALServiceCollectionExtenssions
    {
        public static IServiceCollection AddDALDependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            // Add DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            // Add Repositories
            services.AddTransient(typeof(IBaseRepository<>),typeof(BaseRepository<>));

            // Add UnitOfWork
            services.AddTransient(typeof(IUnitOfWork), typeof(DAL.UnitOfWork.Implementation.UnitOfWork));

            return services;
        }
    }
}

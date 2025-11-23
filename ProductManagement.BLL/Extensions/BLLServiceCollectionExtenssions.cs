using Microsoft.Extensions.DependencyInjection;
using ProductManagement.BLL.Helper;
using ProductManagement.BLL.Services.Implementations;
using ProductManagement.BLL.Services.Interfaces;

namespace ProductManagement.BLL.Extensions;

public static class BLLServiceCollectionExtenssions
{
    public static IServiceCollection AddBLLDependencies(this IServiceCollection services) 
    {
        // Add AutoMapper
        services.AddAutoMapper(typeof(ProductProfile));
        services.AddAutoMapper(typeof(OrderProfle));

        // Add Service
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IOrderService, OrderService>();

        return services;
    }
}

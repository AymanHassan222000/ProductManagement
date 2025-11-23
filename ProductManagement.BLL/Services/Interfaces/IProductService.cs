using ProductManagement.BLL.DTOs.ProductDTOs;
using ProductManagement.BLL.Helper;

namespace ProductManagement.BLL.Services.Interfaces;

public interface IProductService
{
    Task<Result<ProductReadDto>> CreateProductAsync(ProductDto productDto);
    Task<Result<List<ProductReadDto>>> GetAllProductAsync();
    Task<Result<ProductReadDto>> GetProductByIdAsync(int id);
    Task<Result<ProductReadDto>> UpdateProductAsync(int id,ProductDto productDto);
    Task<Result<ProductReadDto>> DeleteProductAsync(int id);

}

using AutoMapper;
using ProductManagement.BLL.DTOs.ProductDTOs;
using ProductManagement.DAL.Models;

namespace ProductManagement.BLL.Helper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDto, Product>();
        CreateMap<Product,ProductReadDto>();
    }
}

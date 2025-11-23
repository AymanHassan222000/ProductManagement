using AutoMapper;
using ProductManagement.BLL.DTOs.ProductDTOs;
using ProductManagement.BLL.Helper;
using ProductManagement.BLL.Services.Interfaces;
using ProductManagement.DAL.Models;
using ProductManagement.DAL.UnitOfWork.Interface;

namespace ProductManagement.BLL.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ProductReadDto>> CreateProductAsync(ProductDto productDto)
    {
        if (productDto.OrderId != null) 
        {
            var order = await _unitOfWork.Orders.GetByIdAsync((int)productDto.OrderId);

            if(order is null)
                return Result<ProductReadDto>.Faliure($"No Order Was Found With Id {productDto.OrderId}",400);
        }

        var product = _mapper.Map<ProductDto, Product>(productDto);

        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.CompleteAsync();

        return Result<ProductReadDto>.Success(_mapper.Map<ProductReadDto>(product), 201);
    }

    public async Task<Result<List<ProductReadDto>>> GetAllProductAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync();

        if (!products.Any())
            return Result<List<ProductReadDto>>.Success(_mapper.Map<List<ProductReadDto>>(products), 204);

        return Result<List<ProductReadDto>>.Success(_mapper.Map<List<ProductReadDto>>(products), 200);
    }

    public async Task<Result<ProductReadDto>> GetProductByIdAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);

        if (product is null)
            return Result<ProductReadDto>.Faliure($"No Product Was Found With id {id}", 404);

        return Result<ProductReadDto>.Success(_mapper.Map<ProductReadDto>(product), 200);
    }

    public async Task<Result<ProductReadDto>> UpdateProductAsync(int id, ProductDto productDto)
    {
        if (productDto.OrderId != null)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync((int)productDto.OrderId);

            if (order is null)
                return Result<ProductReadDto>.Faliure($"No Order Was Found With Id {productDto.OrderId}", 400);
        }

        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product is null)
            return Result<ProductReadDto>.Faliure($"No Product Was Found With id {id}", 404);

        _mapper.Map(productDto,product);

        _unitOfWork.Products.Update(product);
        await _unitOfWork.CompleteAsync();

        return Result<ProductReadDto>.Success(_mapper.Map<ProductReadDto>(product), 200);
    }

    public async Task<Result<ProductReadDto>> DeleteProductAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);

        if (product is null)
            return Result<ProductReadDto>.Faliure($"No Product Was Found With id {id}", 404);

        _unitOfWork.Products.Delete(product);
        await _unitOfWork.CompleteAsync();

        return Result<ProductReadDto>.Success(_mapper.Map<ProductReadDto>(product), 200);
    }

}

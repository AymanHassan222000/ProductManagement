using Microsoft.AspNetCore.Mvc;
using ProductManagement.BLL.DTOs.ProductDTOs;
using ProductManagement.BLL.Services.Interfaces;

namespace ProductManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(ProductDto productDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _productService.CreateProductAsync(productDto);

        if (result.IsFailure)
            return StatusCode(result.StatusCode ?? StatusCodes.Status500InternalServerError, result.Errors);

        return StatusCode(result.StatusCode ?? StatusCodes.Status201Created, result.Value);

    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        var result = await _productService.GetAllProductAsync();

        if (result.IsFailure)
            return StatusCode(result.StatusCode ?? StatusCodes.Status500InternalServerError, result.Errors);

        return StatusCode(result.StatusCode ?? StatusCodes.Status200OK, result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
        var result = await _productService.GetProductByIdAsync(id);

        if (result.IsFailure)
            return StatusCode(result.StatusCode ?? StatusCodes.Status500InternalServerError, result.Errors);

        return StatusCode(result.StatusCode ?? StatusCodes.Status200OK, result.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] ProductDto productDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _productService.UpdateProductAsync(id, productDto);

        if (result.IsFailure)
            return StatusCode(result.StatusCode ?? StatusCodes.Status500InternalServerError, result.Errors);

        return StatusCode(result.StatusCode ?? StatusCodes.Status200OK, result.Value);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        var result = await _productService.DeleteProductAsync(id);

        if (result.IsFailure)
            return StatusCode(result.StatusCode ?? StatusCodes.Status500InternalServerError, result.Errors);

        return StatusCode(result.StatusCode ?? StatusCodes.Status200OK, result.Value);

    }
}

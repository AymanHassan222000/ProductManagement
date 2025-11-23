using Microsoft.AspNetCore.Mvc;
using ProductManagement.BLL.DTOs.OrderDTOs;
using ProductManagement.BLL.Services.Interfaces;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(OrderDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _orderService.CreateOrderAsync(orderDto);

            if (result.IsFailure)
                return StatusCode(result.StatusCode ?? StatusCodes.Status500InternalServerError, result.Errors);

            return StatusCode(result.StatusCode ?? StatusCodes.Status201Created, result.Value);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var result = await _orderService.GetAllOrderAsync();

            if (result.IsFailure)
                return StatusCode(result.StatusCode ?? StatusCodes.Status500InternalServerError, result.Errors);

            return StatusCode(result.StatusCode ?? StatusCodes.Status200OK, result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var result = await _orderService.GetOrderByIdAsync(id);

            if (result.IsFailure)
                return StatusCode(result.StatusCode ?? StatusCodes.Status500InternalServerError, result.Errors);

            return StatusCode(result.StatusCode ?? StatusCodes.Status200OK, result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderAsync(int id, [FromBody] OrderDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _orderService.UpdateOrderAsync(id, orderDto);

            if (result.IsFailure)
                return StatusCode(result.StatusCode ?? StatusCodes.Status500InternalServerError, result.Errors);

            return StatusCode(result.StatusCode ?? StatusCodes.Status200OK, result.Value);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            var result = await _orderService.DeleteOrderAsync(id);

            if (result.IsFailure)
                return StatusCode(result.StatusCode ?? StatusCodes.Status500InternalServerError, result.Errors);

            return StatusCode(result.StatusCode ?? StatusCodes.Status200OK, result.Value);

        }

    }
}

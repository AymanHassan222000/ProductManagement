using ProductManagement.BLL.DTOs.OrderDTOs;
using ProductManagement.BLL.Helper;

namespace ProductManagement.BLL.Services.Interfaces;

public interface IOrderService
{
    Task<Result<OrderReadDto>> CreateOrderAsync(OrderDto orderDto);
    Task<Result<List<OrderReadDto>>> GetAllOrderAsync();
    Task<Result<OrderReadDto>> GetOrderByIdAsync(int id);
    Task<Result<OrderReadDto>> UpdateOrderAsync(int id, OrderDto orderDto);
    Task<Result<OrderReadDto>> DeleteOrderAsync(int id);

}

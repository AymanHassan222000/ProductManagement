using AutoMapper;
using ProductManagement.BLL.DTOs.OrderDTOs;
using ProductManagement.BLL.Helper;
using ProductManagement.BLL.Services.Interfaces;
using ProductManagement.DAL.Models;
using ProductManagement.DAL.UnitOfWork.Interface;

namespace ProductManagement.BLL.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<OrderReadDto>> CreateOrderAsync(OrderDto orderDto)
    {
        var order = _mapper.Map<OrderDto, Order>(orderDto);

        await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.CompleteAsync();

        return Result<OrderReadDto>.Success(_mapper.Map<OrderReadDto>(order), 201);
    }


    public async Task<Result<List<OrderReadDto>>> GetAllOrderAsync()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();

        if (!orders.Any())
            return Result<List<OrderReadDto>>.Success(_mapper.Map<List<OrderReadDto>>(orders), 204);

        return Result<List<OrderReadDto>>.Success(_mapper.Map<List<OrderReadDto>>(orders), 200);

    }

    public async Task<Result<OrderReadDto>> GetOrderByIdAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);

        if (order is null)
            return Result<OrderReadDto>.Faliure($"No Order Was Found With id {id}", 404);

        return Result<OrderReadDto>.Success(_mapper.Map<OrderReadDto>(order), 200);

    }

    public async Task<Result<OrderReadDto>> UpdateOrderAsync(int id, OrderDto orderDto)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        if (order is null)
            return Result<OrderReadDto>.Faliure($"No Order Was Found With id {id}", 404);

        _mapper.Map(orderDto, order);

        _unitOfWork.Orders.Update(order);
        await _unitOfWork.CompleteAsync();

        return Result<OrderReadDto>.Success(_mapper.Map<OrderReadDto>(order), 200);
    }

    public async Task<Result<OrderReadDto>> DeleteOrderAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);

        if (order is null)
            return Result<OrderReadDto>.Faliure($"No Order Was Found With id {id}", 404);

        _unitOfWork.Orders.Delete(order);
        await _unitOfWork.CompleteAsync();

        return Result<OrderReadDto>.Success(_mapper.Map<OrderReadDto>(order), 200);
    }

}

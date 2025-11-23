using AutoMapper;
using ProductManagement.BLL.DTOs.OrderDTOs;
using ProductManagement.DAL.Models;
using ProductManagement.DAL.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.BLL.Helper
{
    public class OrderProfle : Profile
    {

        public OrderProfle()
        {

            CreateMap<OrderDto, Order>();

            CreateMap<Order, OrderReadDto>();
        }
    }
}

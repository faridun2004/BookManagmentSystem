using AutoMapper;
using BookManagmentSystem.Application.CQRS.Orders.Commands;
using BookManagmentSystem.Application.CQRS.Orders.Queries;
using BookManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.Common.Mappings
{
    public class OrderMappings : Profile
    {
        public OrderMappings()
        {
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<UpdateOrderCommand, Order>();
            CreateMap<DeleteOrderCommand, Order>();
            CreateMap<GetAllOrdersQuery, Order>();
            CreateMap<GetOrderByIdQuery, Order>();
        }
    }
}

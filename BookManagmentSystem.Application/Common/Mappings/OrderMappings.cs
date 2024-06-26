using AutoMapper;
using BookManagmentSystem.Application.CQRS.Orders.Commands.Create;
using BookManagmentSystem.Application.CQRS.Orders.Commands.Delete;
using BookManagmentSystem.Application.CQRS.Orders.Commands.Update;
using BookManagmentSystem.Application.CQRS.Orders.Queries.GetAll;
using BookManagmentSystem.Application.CQRS.Orders.Queries.GetById;
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

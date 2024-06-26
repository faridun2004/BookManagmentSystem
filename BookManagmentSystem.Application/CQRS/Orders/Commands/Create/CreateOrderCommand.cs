using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Orders.Commands.Create
{
    public class CreateOrderCommand : IRequest<(Order, string)>
    {
        public int CustomerId { get; set; }
        public List<OrderItemDto>? OrderItems { get; set; }
    }
}

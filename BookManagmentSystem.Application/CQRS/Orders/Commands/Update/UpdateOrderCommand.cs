using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Orders.Commands.Update
{
    public class UpdateOrderCommand : IRequest<(bool, string)>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}

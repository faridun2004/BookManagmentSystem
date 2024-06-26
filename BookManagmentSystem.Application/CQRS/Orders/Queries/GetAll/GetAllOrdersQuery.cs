using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Orders.Queries.GetAll
{
    public class GetAllOrdersQuery : IRequest<List<Order>>
    {
    }
}

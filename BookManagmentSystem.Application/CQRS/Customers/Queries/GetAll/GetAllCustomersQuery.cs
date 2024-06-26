using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Customers.Queries.GetAll
{
    public class GetAllCustomersQuery : IRequest<List<Customer>>
    {
    }
}

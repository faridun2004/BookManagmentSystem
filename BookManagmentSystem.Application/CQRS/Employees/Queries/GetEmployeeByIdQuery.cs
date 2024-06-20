using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Employees.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public Guid Id { get; set; }
    }
}

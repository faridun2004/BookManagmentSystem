using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Employees.Queries.GetById
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public Guid Id { get; set; }

        // Публичный конструктор без параметров
        public GetEmployeeByIdQuery()
        {
        }

        // Вариант конструктора с параметром
        public GetEmployeeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}

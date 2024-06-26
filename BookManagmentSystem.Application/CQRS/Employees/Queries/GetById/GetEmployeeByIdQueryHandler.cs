using AutoMapper;
using BookManagmentSystem.Application.CQRS.Categories.Queries;
using BookManagmentSystem.Application.Interfaces;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Employees.Queries.GetById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private IEmployeeService _service;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _service.GetById(request.Id);
            return client;
        }
    }
}

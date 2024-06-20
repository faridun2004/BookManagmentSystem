using AutoMapper;
using BookManagmentSystem.Application.Common.Interfaces;
using BookManagmentSystem.Application.CQRS.Categories.Queries;
using BookManagmentSystem.Application.CQRS.Employees.Queries;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Employees.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<Employee>>
    {
        private IEmployeeService _service;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var clients = _service.GetAll().ToList();
            return await Task.FromResult(clients);
        }
    }
}

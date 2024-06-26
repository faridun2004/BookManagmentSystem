using AutoMapper;
using BookManagmentSystem.Application.CQRS.Categories.Commands;
using BookManagmentSystem.Application.Interfaces;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Employees.Commands.Update
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, (bool, string)>
    {
        private IEmployeeService _service;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(bool, string)> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);
            var result = _service.TryUpdate(request.Id, employee, out string message); ;

            return Task.FromResult((result, message));
        }

    }
}

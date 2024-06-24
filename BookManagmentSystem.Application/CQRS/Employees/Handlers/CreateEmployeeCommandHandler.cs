using AutoMapper;
using BookManagmentSystem.Application.CQRS.Categories.Commands;
using BookManagmentSystem.Application.CQRS.Employees.Commands;
using BookManagmentSystem.Application.Interfaces;
using BookManagmentSystem.Domain.Entities;
using MediatR;

namespace BookManagmentSystem.Application.CQRS.Employees.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, (Employee, string)>
    {
        private IEmployeeService _service;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(Employee, string)> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);
            var createdItem = _service.TryCreate(employee, out string message);
            return Task.FromResult((createdItem, message));
        }
    }
}

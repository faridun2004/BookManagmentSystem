using AutoMapper;
using BookManagmentSystem.Application.CQRS.Customers.Commands;
using BookManagmentSystem.Application.CQRS.Employees.Commands;
using BookManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using MediatR;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagmentSystem.Application.Interfaces;

namespace BookManagmentSystem.Application.CQRS.Customers.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, (bool, string)>
    {
        private ICustomerService _service;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(bool, string)> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);
            var result = _service.TryUpdate(request.Id, customer, out string message); ;

            return Task.FromResult((result, message));
        }

    }
}

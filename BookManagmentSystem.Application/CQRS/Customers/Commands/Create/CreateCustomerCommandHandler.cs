using AutoMapper;
using BookManagmentSystem.Application.Interfaces;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Customers.Commands.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, (Customer, string)>
    {
        private ICustomerService _service;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public Task<(Customer, string)> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(command);
            var createdItem = _service.TryCreate(customer, out string message);
            return Task.FromResult((createdItem, message));
        }
    }
}

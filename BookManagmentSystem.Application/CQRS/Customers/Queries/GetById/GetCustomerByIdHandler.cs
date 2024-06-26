using AutoMapper;
using BookManagmentSystem.Application.CQRS.Employees.Queries;
using BookManagmentSystem.Domain.Entities;
using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagmentSystem.Application.Interfaces;

namespace BookManagmentSystem.Application.CQRS.Customers.Queries.GetById
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private ICustomerService _service;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _service.GetById(request.Id);
            return customer;
        }
    }
}

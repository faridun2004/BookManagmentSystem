﻿using AutoMapper;
using BookManagmentSystem.Application.CQRS.Employees.Queries;
using MediatR;
using BookManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagmentSystem.Application.Interfaces;

namespace BookManagmentSystem.Application.CQRS.Customers.Queries.GetAll
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<Customer>>
    {
        private ICustomerService _service;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = _service.GetAll().ToList();
            return await Task.FromResult(customers);
        }
    }
}

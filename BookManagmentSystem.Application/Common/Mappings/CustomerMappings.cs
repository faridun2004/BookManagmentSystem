using AutoMapper;
using BookManagmentSystem.Application.CQRS.Customers.Commands.Create;
using BookManagmentSystem.Application.CQRS.Customers.Commands.Delete;
using BookManagmentSystem.Application.CQRS.Customers.Commands.Update;
using BookManagmentSystem.Application.CQRS.Customers.Queries.GetAll;
using BookManagmentSystem.Application.CQRS.Customers.Queries.GetById;
using BookManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.Common.Mappings
{
    public class CustomerMappings : Profile
    {
        public CustomerMappings()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();
            CreateMap<DeleteCustomerCommand, Customer>();
            CreateMap<GetAllCustomersQuery, Customer>();
            CreateMap<GetCustomerByIdQuery, Customer>();
        }
    }
}

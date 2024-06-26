using BookManagmentSystem.Application.CQRS.Customers.Commands.Create;
using BookManagmentSystem.Application.CQRS.Customers.Commands.Delete;
using BookManagmentSystem.Application.CQRS.Customers.Commands.Update;
using BookManagmentSystem.Application.CQRS.Customers.Queries.GetAll;
using BookManagmentSystem.Application.CQRS.Customers.Queries.GetById;
using BookManagmentSystem.Application.CQRS.Employees.Commands;
using BookManagmentSystem.Application.CQRS.Employees.Queries;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagmentSystem.API.Controllers
{
    [ApiController]
    [Route("Customer")]
    public class CustomerController : BaseController<
    CreateCustomerCommand,
    UpdateCustomerCommand,
    DeleteCustomerCommand,
    GetCustomerByIdQuery,
    GetAllCustomersQuery,
    Customer,
    Guid>
    {
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }
    }
}

using BookManagmentSystem.Application.CQRS.Customers.Commands;
using BookManagmentSystem.Application.CQRS.Customers.Queries;
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

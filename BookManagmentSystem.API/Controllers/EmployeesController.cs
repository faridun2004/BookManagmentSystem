using BookManagmentSystem.Application.CQRS.Employees.Commands;
using BookManagmentSystem.Application.CQRS.Employees.Queries;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagmentSystem.API.Controllers
{
    [ApiController]
    [Route("Employee")]
     public class EmployeesController : BaseController<
     CreateEmployeeCommand,
     UpdateEmployeeCommand,
     DeleteEmployeeCommand,
     GetEmployeeByIdQuery,
     GetAllEmployeesQuery,
     Employee,
     Guid>
    {
        public EmployeesController(IMediator mediator) : base(mediator)
        {
        }
    }

}

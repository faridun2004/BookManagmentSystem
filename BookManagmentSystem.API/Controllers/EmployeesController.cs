using BookManagmentSystem.Application.Common.Interfaces;
using BookManagmentSystem.Application.CQRS.Employees.Commands;
using BookManagmentSystem.Application.CQRS.Employees.Queries;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Common.Http;

namespace BookManagmentSystem.API.Controllers
{
    [ApiController]
    [Route("Employee")]
    public class EmployeesController : ControllerBase
    {
        protected readonly IEmployeeService _employeeService;
        
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("AllEmployee")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var query = new GetAllEmployeesQuery();
            var employees = await _mediator.Send(query);
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(Guid id)
        {
            var query = new GetEmployeeByIdQuery() { Id = id };
            var employee = await _mediator.Send(query);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(CreateEmployeeCommand command)
        {
            var (createdItem, message) = await _mediator.Send(command);
            if (createdItem is null)
                return BadRequest(message);

            return Ok(createdItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateEmployee(Guid id, UpdateEmployeeCommand command)
        {
            command.EmployeeId = id;
            var (result, message) = await _mediator.Send(command);
            if (result)
                return Ok(message);

            return BadRequest(message);
        }

        [HttpDelete]
        public async Task<IActionResult> Deleteemployee(DeleteEmployeeCommand deleteEmployee)
        {
            var (result, message) = await _mediator.Send(deleteEmployee);
            if (result)
                return Ok(message);

            return BadRequest(message);
        }
    }
}

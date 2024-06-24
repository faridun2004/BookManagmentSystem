using BookManagmentSystem.Application.CQRS.Categories.Commands;
using BookManagmentSystem.Application.CQRS.Categories.Queries;
using BookManagmentSystem.Application.CQRS.Employees.Commands;
using BookManagmentSystem.Application.CQRS.Employees.Queries;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookManagmentSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("AllEmployee")]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery();
            var employees = await _mediator.Send(query);
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(Guid id)
        {
            var query = new GetCategoryByIdQuery() { Id = id };
            var employee = await _mediator.Send(query);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CreateCategoryCommand command)
        {
            var (createdItem, message) = await _mediator.Send(command);
            if (createdItem is null)
                return BadRequest(message);

            return Ok(createdItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateCategory(Guid id, UpdateCategoryCommand command)
        {
            command.Id = id;
            var (result, message) = await _mediator.Send(command);
            if (result)
                return Ok(message);

            return BadRequest(message);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand deleteEmployee)
        {
            var (result, message) = await _mediator.Send(deleteEmployee);
            if (result)
                return Ok(message);

            return BadRequest(message);
        }
    }
}

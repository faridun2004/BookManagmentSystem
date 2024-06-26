using BookManagmentSystem.Application.CQRS.Orders.Commands.Create;
using BookManagmentSystem.Application.CQRS.Orders.Commands.Delete;
using BookManagmentSystem.Application.CQRS.Orders.Commands.Update;
using BookManagmentSystem.Application.CQRS.Orders.Queries;
using BookManagmentSystem.Application.CQRS.Orders.Queries.GetAll;
using BookManagmentSystem.Application.CQRS.Orders.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateOrderCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteOrderCommand { Id = id });
            return NoContent();
        }
    }
}

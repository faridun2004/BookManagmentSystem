using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookManagmentSystem.API.Controllers
{
    [ApiController]
    
    public abstract class BaseController<
    TCreateCommand,
    TUpdateCommand,
    TDeleteCommand,
    TGetByIdQuery,
    TGetAllQuery,
    TDto,
    TKey> : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public virtual async Task<ActionResult<List<TDto>>> GetAll()
        {
            var query = Activator.CreateInstance<TGetAllQuery>();
            var items = await _mediator.Send(query);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TDto>> GetById(TKey id)
        {
            var query = Activator.CreateInstance<TGetByIdQuery>();
            var property = typeof(TGetByIdQuery).GetProperty("Id");
            if (property != null && property.PropertyType == typeof(TKey))
            {
                property.SetValue(query, id);
            }
            var item = await _mediator.Send((IRequest<TDto>)query);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TDto>> Create(TCreateCommand command)
        {
            var result = await _mediator.Send(command);
            (TDto createdItem, string message) = ((TDto, string))result;
            if (createdItem is null)
                return BadRequest(message);

            return Ok(createdItem);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<string>> Update(TKey id, TUpdateCommand command)
        {
            var property = typeof(TUpdateCommand).GetProperty("Id");
            if (property != null && property.PropertyType == typeof(TKey))
            {
                property.SetValue(command, id);
            }
            var result = await _mediator.Send(command);
            (bool isSuccess, string message) = ((bool, string))result;
            if (isSuccess)
                return Ok(message);

            return BadRequest(message);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(TKey id, TDeleteCommand command)
        {
            var property = typeof(TDeleteCommand).GetProperty("Id");
            if (property != null && property.PropertyType == typeof(TKey))
            {
                property.SetValue(command, id);
            }
            var result = await _mediator.Send(command);
            (bool isSuccess, string message) = ((bool, string))result;
            if (isSuccess)
                return Ok(message);

            return BadRequest(message);
        }
    }
}

using BookManagmentSystem.Application.CQRS.Authors.Commands;
using BookManagmentSystem.Application.CQRS.Authors.Queries;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Common.Http;

namespace BookManagmentSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Author>> CreateClient(CreateAuthorCommand command)
        {
            var (createdItem, message) = await _mediator.Send(command);
            if (createdItem is null)
                return BadRequest(message);
            return Ok(createdItem);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetClientById(Guid id)
        {
            var query = new GetAuthorByIdQuery() { Id = id };
            var client = await _mediator.Send(query);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        [HttpGet("AllClients")]
        public async Task<ActionResult<List<Author>>> GetAllClients()
        {
            var query = new GetAllAuthorsQuery();
            var clients = await _mediator.Send(query);
            return Ok(clients);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateClient(Guid id, UpdateAuthorCommand command)
        {
            command.Id = id;
            var (result, message) = await _mediator.Send(command);
            if (result)
                return Ok(message);

            return BadRequest(message);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteAuthorCommand deleteClient)
        {
            var (result, message) = await _mediator.Send(deleteClient);
            if (result)
                return Ok(message);

            return BadRequest(message);
        }
    }
}

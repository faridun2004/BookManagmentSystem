using BookManagmentSystem.Application.CQRS.Authors.Commands.Create;
using BookManagmentSystem.Application.CQRS.Authors.Commands.Delete;
using BookManagmentSystem.Application.CQRS.Authors.Commands.Update;
using BookManagmentSystem.Application.CQRS.Authors.Queries;
using BookManagmentSystem.Application.CQRS.Authors.Queries.GetAll;
using BookManagmentSystem.Application.CQRS.Authors.Queries.GetById;
using BookManagmentSystem.Application.CQRS.Books.Commands.Create;
using BookManagmentSystem.Application.CQRS.Books.Commands.Delete;
using BookManagmentSystem.Application.CQRS.Books.Commands.Update;
using BookManagmentSystem.Application.CQRS.Books.Queries.GetAll;
using BookManagmentSystem.Application.CQRS.Books.Queries.GetById;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Common.Http;

namespace BookManagmentSystem.API.Controllers
{
    [ApiController]
    [Route("Authors")]
    public class AuthorsController : BaseController<

    CreateAuthorCommand,
    UpdateAuthorCommand,
    DeleteAuthorCommand,
    GetAuthorByIdQuery,
    GetAllAuthorsQuery,
    Author,
    Guid>
    {
        public AuthorsController(IMediator mediator) : base(mediator)
        {
        }
    }
}

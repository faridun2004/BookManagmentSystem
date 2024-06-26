using BookManagmentSystem.Application.CQRS.Books.Commands;
using BookManagmentSystem.Application.CQRS.Books.Commands.Create;
using BookManagmentSystem.Application.CQRS.Books.Commands.Delete;
using BookManagmentSystem.Application.CQRS.Books.Commands.Update;
using BookManagmentSystem.Application.CQRS.Books.Queries;
using BookManagmentSystem.Application.CQRS.Books.Queries.GetAll;
using BookManagmentSystem.Application.CQRS.Books.Queries.GetById;
using BookManagmentSystem.Application.CQRS.Customers.Commands;
using BookManagmentSystem.Application.CQRS.Customers.Queries;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagmentSystem.API.Controllers
{
    [ApiController]
    [Route("Book")]
    public class BooksController : BaseController<
    CreateBookCommand,
    UpdateBookCommand,
    DeleteBookCommand,
    GetBookByIdQuery,
    GetAllBooksQuery,
    Book,
    Guid>
    {
        public BooksController(IMediator mediator) : base(mediator)
        {
        }
    }
}

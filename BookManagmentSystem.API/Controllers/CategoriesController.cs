using BookManagmentSystem.Application.CQRS.Books.Commands.Create;
using BookManagmentSystem.Application.CQRS.Books.Commands.Delete;
using BookManagmentSystem.Application.CQRS.Books.Commands.Update;
using BookManagmentSystem.Application.CQRS.Books.Queries.GetAll;
using BookManagmentSystem.Application.CQRS.Books.Queries.GetById;
using BookManagmentSystem.Application.CQRS.Categories.Commands.Create;
using BookManagmentSystem.Application.CQRS.Categories.Commands.Delete;
using BookManagmentSystem.Application.CQRS.Categories.Commands.Update;
using BookManagmentSystem.Application.CQRS.Categories.Queries.GetAll;
using BookManagmentSystem.Application.CQRS.Categories.Queries.GetById;
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
    public class CategoriesController : BaseController<
    CreateCategoryCommand,
    UpdateCategoryCommand,
    DeleteCategoryCommand,
    GetCategoryByIdQuery,
    GetAllCategoriesQuery,
    Category,
    Guid>
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }
    }
}

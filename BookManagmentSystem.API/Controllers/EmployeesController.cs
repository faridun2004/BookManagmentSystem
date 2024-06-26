﻿using BookManagmentSystem.Application.CQRS.Employees.Commands.Create;
using BookManagmentSystem.Application.CQRS.Employees.Commands.Delete;
using BookManagmentSystem.Application.CQRS.Employees.Commands.Update;
using BookManagmentSystem.Application.CQRS.Employees.Queries.GetAll;
using BookManagmentSystem.Application.CQRS.Employees.Queries.GetById;
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

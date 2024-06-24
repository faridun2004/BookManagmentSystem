using AutoMapper;
using BookManagmentSystem.Application.CQRS.Employees.Commands;
using BookManagmentSystem.Application.CQRS.Employees.Queries;
using BookManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.Common.Mappings
{
    public class EmployeeMappings : Profile
    {
        public EmployeeMappings()
        {

            CreateMap<CreateEmployeeCommand, Employee>();
            CreateMap<UpdateEmployeeCommand, Employee>();
            CreateMap<DeleteEmployeeCommand, Employee>();
        }
    }
}

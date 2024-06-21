using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<(Customer, string)>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? FullName => $"{FirstName} {LastName}";

        public string? Address { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
}

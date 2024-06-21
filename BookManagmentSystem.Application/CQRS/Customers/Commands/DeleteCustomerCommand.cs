using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest<(bool, string)>
    {
        public Guid Id { get; set; }

        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }
    }

}

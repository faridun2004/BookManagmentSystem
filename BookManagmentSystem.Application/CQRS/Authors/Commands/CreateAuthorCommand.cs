using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Authors.Commands
{
    public class CreateAuthorCommand : IRequest<(Author,string)>
    {
        public string FullName { get; set; }
    }
}

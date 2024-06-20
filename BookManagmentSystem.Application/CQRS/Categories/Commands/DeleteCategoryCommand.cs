using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<(bool, string)>   
    {
        [FromQuery]
        public Guid Id { get; set; }
    }
}

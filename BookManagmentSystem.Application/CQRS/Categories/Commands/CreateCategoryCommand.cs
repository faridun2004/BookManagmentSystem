using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<(Category,string)>
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Books.Commands.Update
{
    public class UpdateBookCommand : IRequest<(bool, string)>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}

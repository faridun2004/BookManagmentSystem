using MediatR;
using BookManagmentSystem.Domain.Entities;

namespace BookManagmentSystem.Application.CQRS.Books.Commands.Create
{
    public class CreateBookCommand : IRequest<(Book, string)>
    {
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public Category? Category { get; set; }
        public Author?Author { get; set; }
    }

}

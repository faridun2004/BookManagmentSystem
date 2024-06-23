using AutoMapper;
using BookManagmentSystem.Application.Interfaces;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Books.Commands.Create
{

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, (Book, string)>
    {
        private IBookService _service;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(Book, string)> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Book>(request);
            var createdItem = _service.TryCreate(user, out string message);
            return Task.FromResult((createdItem, message));
        }
    }
}

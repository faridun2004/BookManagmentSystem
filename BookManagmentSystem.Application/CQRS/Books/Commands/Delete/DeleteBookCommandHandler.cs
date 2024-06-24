using AutoMapper;
using BookManagmentSystem.Application.Interfaces;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Books.Commands.Delete
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, (bool, string)>
    {
        private IBookService _service;
        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(IBookService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(bool, string)> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var result = _service.TryDelete(request.Id, out string message);
            return Task.FromResult((result, message));
        }
    }
}

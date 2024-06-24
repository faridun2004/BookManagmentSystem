using AutoMapper;
using BookManagmentSystem.Application.Interfaces;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Books.Commands.Update
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, (bool, string)>
    {
        private IBookService _service;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(bool, string)> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Book>(request);
            var result = _service.TryUpdate(request.Id, client, out string message);
            return Task.FromResult((result, message));
        }
    }
}

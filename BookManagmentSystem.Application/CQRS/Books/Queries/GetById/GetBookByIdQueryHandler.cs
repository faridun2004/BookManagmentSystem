using AutoMapper;
using BookManagmentSystem.Application.Interfaces;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Books.Queries.GetById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private IBookService _service;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IBookService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _service.GetById(request.Id);
            return client;
        }
    }
}


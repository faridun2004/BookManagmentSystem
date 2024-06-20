using AutoMapper;
using BookManagmentSystem.Application.Common.Interfaces;
using BookManagmentSystem.Application.CQRS.Books.Queries;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Books.Handlers
{
    
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private IBookService _service;
        private readonly IMapper _mapper;

        public GetAllBooksQueryHandler(IBookService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var clients = _service.GetAll().ToList();
            return await Task.FromResult(clients);
        }
    }
}

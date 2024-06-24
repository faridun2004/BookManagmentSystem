using AutoMapper;
using BookManagmentSystem.Application.Interfaces;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Authors.Commands.Delete
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, (bool, string)>
    {
        private IAuthorService _service;
        private readonly IMapper _mapper;

        public DeleteAuthorCommandHandler(IAuthorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(bool, string)> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var result = _service.TryDelete(request.Id, out string message);
            return Task.FromResult((result, message));
        }
    }
}

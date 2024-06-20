using AutoMapper;
using BookManagmentSystem.Application.Common.Interfaces;
using BookManagmentSystem.Application.CQRS.Authors.Commands;
using BookManagmentSystem.Domain.Entities;
using MediatR;

namespace BookManagmentSystem.Application.CQRS.Authors.Handlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, (Author, string)>
    {
        private IAuthorService _service;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(Author, string)> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Author>(request);
            var createdItem = _service.TryCreate(user, out string message);
            return Task.FromResult((createdItem, message));
        }
    }
}

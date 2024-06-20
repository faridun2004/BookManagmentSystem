using AutoMapper;
using BookManagmentSystem.Application.Common.Interfaces;
using BookManagmentSystem.Application.CQRS.Authors.Commands;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using Optivem.Framework.Core.Common.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Authors.Handlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, (bool, string)>
    {
        private IAuthorService _service;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(bool, string)> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Author>(request);
            var result = _service.TryUpdate(request.Id, client, out string message);
            return Task.FromResult((result, message));
        }
    }
}

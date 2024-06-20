using AutoMapper;
using BookManagmentSystem.Application.Common.Interfaces;
using BookManagmentSystem.Application.CQRS.Categories.Commands;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Categories.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, (bool, string)>
    {
        private ICategoryService _service;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(bool, string)> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = _service.TryDelete(request.Id, out string message);
            return Task.FromResult((result, message));
        }
    }
}

using AutoMapper;
using BookManagmentSystem.Application.Interfaces;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using Optivem.Framework.Core.Common.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Categories.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, (Category, string)>
    {
        private ICategoryService _service;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(Category, string)> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Category>(request);
            var createdItem = _service.TryCreate(user, out string message);
            return Task.FromResult((createdItem, message));
        }
    }
}

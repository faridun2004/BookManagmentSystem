using AutoMapper;
using BookManagmentSystem.Application.CQRS.Categories.Queries;
using BookManagmentSystem.Application.Interfaces;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using Optivem.Framework.Core.Common.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Categories.Handlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private ICategoryService _service;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _service.GetById(request.Id);
            return client;
        }
    }
}

using AutoMapper;
using BookManagmentSystem.Application.Common.Interfaces;
using BookManagmentSystem.Application.CQRS.Categories.Queries;
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
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
    {
        private ICategoryService _service;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var clients = _service.GetAll().ToList();
            return await Task.FromResult(clients);
        }
    }
}


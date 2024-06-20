using AutoMapper;
using BookManagmentSystem.Application.Common.Interfaces;
using BookManagmentSystem.Application.CQRS.Authors.Queries;

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
        public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<Author>>
        {
            private IAuthorService _service;
            private readonly IMapper _mapper;

            public GetAllAuthorsQueryHandler(IAuthorService service, IMapper mapper)
            {
                _service = service;
                _mapper = mapper;
            }

            public async Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
            {
                var clients = _service.GetAll().ToList();
                return await Task.FromResult(clients);
            }
        }
    }

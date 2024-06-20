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
        public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
        {
            private IAuthorService _service;
            private readonly IMapper _mapper;

            public GetAuthorByIdQueryHandler(IAuthorService service, IMapper mapper)
            {
                _service = service;
                _mapper = mapper;
            }
            public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
            {
                var client = await _service.GetById(request.Id);
                return client;
            }
        }
    }


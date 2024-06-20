using AutoMapper;
using BookManagmentSystem.Application.Common.Interfaces;
using BookManagmentSystem.Application.CQRS.Orders.Queries;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using Optivem.Framework.Core.Common.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Orders.Handlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<Order>>
    {
        private IOrderService _service;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var clients = _service.GetAll().ToList();
            return await Task.FromResult(clients);
        }
    }
}

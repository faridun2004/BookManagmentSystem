using AutoMapper;
using BookManagmentSystem.Application.Common.Interfaces;
using BookManagmentSystem.Application.CQRS.Orders.Commands;
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
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, (Order, string)>
    {
        private IOrderService _service;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(Order, string)> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Order>(request);
            var createdItem = _service.TryCreate(user, out string message);
            return Task.FromResult((createdItem, message));
        }
    }
}

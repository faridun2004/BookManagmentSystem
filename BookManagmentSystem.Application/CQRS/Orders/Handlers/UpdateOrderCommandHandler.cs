using AutoMapper;
using BookManagmentSystem.Application.CQRS.Orders.Commands;
using BookManagmentSystem.Application.Interfaces;
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
    public class UpdateClientCommandHandler : IRequestHandler<UpdateOrderCommand, (bool, string)>
    {
        private IOrderService _service;
        private readonly IMapper _mapper;

        public UpdateClientCommandHandler(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(bool, string)> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Order>(request);
            var result = _service.TryUpdate(request.Id, client, out string message);
            return Task.FromResult((result, message));
        }
    }
}

using AutoMapper;
using BookManagmentSystem.Application.Common.Interfaces;
using BookManagmentSystem.Application.CQRS.Orders.Commands;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Orders.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, (bool, string)>
    {
        private IOrderService _service;
        private readonly IMapper _mapper;

        public DeleteOrderCommandHandler(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(bool, string)> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var result = _service.TryDelete(request.Id, out string message);
            return Task.FromResult((result, message));
        }
    }
}

using AutoMapper;
using BookManagmentSystem.Application.CQRS.Employees.Commands;
using BookManagmentSystem.Application.Interfaces;
using MediatR;

namespace BookManagmentSystem.Application.CQRS.Customers.Commands.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, (bool, string)>
    {
        private ICustomerService _service;
        private readonly IMapper _mapper;

        public DeleteCustomerCommandHandler(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(bool, string)> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = _service.TryDelete(request.Id, out string message);
            return Task.FromResult((result, message));
        }
    }
}

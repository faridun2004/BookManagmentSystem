using AutoMapper;
using BookManagmentSystem.Application.Interfaces;
using BookManagmentSystem.Domain.Entities;
using MediatR;

namespace BookManagmentSystem.Application.CQRS.Categories.Commands.Update
{

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, (bool, string)>
    {
        private ICategoryService _service;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<(bool, string)> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Category>(request);
            var result = _service.TryUpdate(request.Id, client, out string message);
            return Task.FromResult((result, message));
        }
    }
}

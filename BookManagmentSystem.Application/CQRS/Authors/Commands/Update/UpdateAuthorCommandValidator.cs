using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BookManagmentSystem.Application.CQRS.Authors.Commands.Update
{
    public sealed class UpdateAuthorCommandValidator: AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(200);
        }

    }
}

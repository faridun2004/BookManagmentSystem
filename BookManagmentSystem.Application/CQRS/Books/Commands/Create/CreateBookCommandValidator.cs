using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Books.Commands.Create
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl is required.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("ImageUrl must be a valid URL.");

            RuleFor(x => x.Category)
                .NotNull().WithMessage("Category is required.");

            RuleFor(x => x.Author)
                .NotNull().WithMessage("Author is required.");
        }
    }
}

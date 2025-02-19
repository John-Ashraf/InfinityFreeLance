using Api.Core.Features.Products.Commands.Models;
using FluentValidation;

namespace Api.Core.Features.Products.Commands.Validators
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #region Actions
        public void ApplyValidationsRules()
        {
            _ = RuleFor(x => x.id)
                 .NotEmpty().WithMessage("id must be not empty")
                 .NotNull().WithMessage("id must be not null");

        }

        public void ApplyCustomValidationsRules()
        {
        }
        #endregion
    }
}

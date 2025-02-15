using Api.Core.Features.Categories.Commands.Models;
using FluentValidation;

namespace Api.Core.Features.Categories.Commands.Validators
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #region Actions
        public void ApplyValidationsRules()
        {
            _ = RuleFor(x => x.id)
                 .NotEmpty().WithMessage("Name must be not empty")
                 .NotNull().WithMessage("Name must be not null");


        }

        public void ApplyCustomValidationsRules()
        {
        }
        #endregion
    }
}

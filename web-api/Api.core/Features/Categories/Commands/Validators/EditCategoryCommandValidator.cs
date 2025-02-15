using Api.Core.Features.Categories.Commands.Models;
using FluentValidation;

namespace Api.Core.Features.Categories.Commands.Validators
{
    public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #region Actions
        public void ApplyValidationsRules()
        {
            _ = RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Name must be not empty")
                 .NotNull().WithMessage("Name must be not null");

            _ = RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id must be not empty")
                .NotNull().WithMessage("Id must be not null");
        }

        public void ApplyCustomValidationsRules()
        {
        }
        #endregion

    }
}

using Api.Core.Features.News.Commands.Models;
using FluentValidation;

namespace Api.Core.Features.News.Commands.Validators
{
    public class AddNewsCommandValidator : AbstractValidator<AddNewsCommand>
    {
        public AddNewsCommandValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #region Actions
        public void ApplyValidationsRules()
        {
            _ = RuleFor(x => x.Title)
                 .NotEmpty().WithMessage("Name must be not empty!!")
                 .NotNull().WithMessage("Name must be not null");
            _ = RuleFor(x => x.Content)
                 .NotEmpty().WithMessage("Price must be not empty")
                 .NotNull().WithMessage("Price must be not null");
            _ = RuleFor(x => x.Photo)
                 .NotEmpty().WithMessage("Photos must be not empty")
                 .NotNull().WithMessage("Photos must be not null");


        }

        public void ApplyCustomValidationsRules()
        {
        }
        #endregion
    }
}

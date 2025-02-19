using Api.Core.Features.Products.Commands.Models;
using FluentValidation;

namespace Api.Core.Features.Products.Commands.Validators
{
    public class AddProductCommandValidator : AbstractValidator<AddproductCommand>
    {
        public AddProductCommandValidator()
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
            _ = RuleFor(x => x.Price)
     .NotEmpty().WithMessage("Price must be not empty")
     .NotNull().WithMessage("Price must be not null");
            _ = RuleFor(x => x.Photos)
     .NotEmpty().WithMessage("Photos must be not empty")
     .NotNull().WithMessage("Photos must be not null");
            _ = RuleFor(x => x.Catid)
     .NotEmpty().WithMessage("Catid must be not empty")
     .NotNull().WithMessage("Catid must be not null");
            _ = RuleFor(x => x.Description)
     .NotEmpty().WithMessage("Description must be not empty")
     .NotNull().WithMessage("Description must be not null");

        }

        public void ApplyCustomValidationsRules()
        {
        }
        #endregion
    }
}

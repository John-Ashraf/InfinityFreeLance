using Api.Core.Features.Orders.Commands.Models;
using Api.Service.Abstracts;
using FluentValidation;

namespace Api.Core.Features.Orders.Commands.Validators
{
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
        IProductService _productService;
        public AddOrderCommandValidator(IProductService productService)
        {
            _productService = productService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #region Actions
        public void ApplyValidationsRules()
        {
            _ = RuleFor(x => x.size)
                 .NotEmpty().WithMessage("size must be not empty")
                 .NotNull().WithMessage("size must be not null");
            _ = RuleFor(x => x.Quantity)
                 .NotEmpty().WithMessage("Quantity must be not empty")
                 .NotNull().WithMessage("Quantity must be not null");

            _ = RuleFor(x => x.Address)
                 .NotEmpty().WithMessage("Address must be not empty")
                 .NotNull().WithMessage("Address must be not null");
            _ = RuleFor(x => x.Phone)
                 .NotEmpty().WithMessage("Phone must be not empty")
                 .NotNull().WithMessage("Phone must be not null");
            _ = RuleFor(x => x.Email)
             .NotEmpty().WithMessage("Email must be not empty")
             .NotNull().WithMessage("Email must be not null");
            _ = RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name must be not empty")
            .NotNull().WithMessage("Name must be not null");

        }

        public async void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}

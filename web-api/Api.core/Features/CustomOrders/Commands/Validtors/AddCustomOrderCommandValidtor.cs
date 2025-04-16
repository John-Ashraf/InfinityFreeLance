using Api.Core.Features.CustomOrders.Commands.Models;
using FluentValidation;

namespace Api.Core.Features.CustomOrders.Commands.Validtors;
public class AddCustomOrderCommandValidtor : AbstractValidator<AddCustomOrderCommand>
{
    #region fields
    #endregion
    #region constructor
    public AddCustomOrderCommandValidtor()
    {
        ApplyValidationsRules();
        ApplyCustomValidationsRules();
    }
    #endregion
    #region handlefunctions
    public void ApplyValidationsRules()
    {
        _ = RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} Must Not Be Empty")
        .NotNull().WithMessage("{PropertyName} Must Be Null"); ;

        _ = RuleFor(x => x.Size)
            .NotEmpty().WithMessage("{PropertyName} Must Not Be Empty")
            .NotNull().WithMessage("{PropertyName} Must Be Null");

        _ = RuleFor(x => x.Address)
           .NotEmpty().WithMessage("{PropertyName} Must Not Be Empty")
           .NotNull().WithMessage("{PropertyName} Must Be Null");
        _ = RuleFor(x => x.Photos)
        .NotEmpty().WithMessage("{PropertyName} Must Not Be Empty")
        .NotNull().WithMessage("{PropertyName} Must Be Null");
        _ = RuleFor(x => x.Email)
           .NotEmpty().WithMessage("{PropertyName} Must Not Be Empty")
           .NotNull().WithMessage("{PropertyName} Must Be Null");
        _ = RuleFor(x => x.Notes)
         .NotEmpty().WithMessage("{PropertyName} Must Not Be Empty")
         .NotNull().WithMessage("{PropertyName} Must Be Null");
        _ = RuleFor(x => x.TotalPrice)
          .NotEmpty().WithMessage("{PropertyName} Must Not Be Empty")
          .NotNull().WithMessage("{PropertyName} Must Be Null");
        _ = RuleFor(x => x.Phone)
         .NotEmpty().WithMessage("{PropertyName} Must Not Be Empty")
         .NotNull().WithMessage("{PropertyName} Must Be Null");



    }
    public void ApplyCustomValidationsRules()// el false hwa el bedrb error
    {

    }
    #endregion
}

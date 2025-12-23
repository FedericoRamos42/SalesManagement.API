using Application.Services.Sales.Models.Request;
using FluentValidation;

namespace Application.Services.Sales.Validators
{
    public class CreateSaleValidator: AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleValidator()
        {
            RuleFor(x => x.CustomerId)
           .GreaterThan(0)
           .WithMessage("CustomerId must be a valid value");

            RuleFor(x => x.PaymentMethod)
                .IsInEnum()
                .WithMessage("Paymenth method is invalid");

            RuleFor(x => x.Details)
                .NotNull()
                .WithMessage("Sale must have items")
                .NotEmpty()
                .WithMessage("Sale must contain at least one item");

            RuleForEach(x => x.Details)
                .SetValidator(new CreateSaleDetailValidator());
        }
    }
}

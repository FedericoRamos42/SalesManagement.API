using Application.Services.Products.Models.Request;
using FluentValidation;

namespace Application.Services.Products.Validators
{
    public class UpdateProductStockValidator : AbstractValidator<UpdateStockRequest>
    {
        public UpdateProductStockValidator()
        {
            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Stock cannot be negative");
        }
    }
}

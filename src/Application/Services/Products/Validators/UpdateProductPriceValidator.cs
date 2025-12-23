using Application.Services.Products.Models.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Validators
{
    public class UpdateProductPriceValidator : AbstractValidator<UpdatePriceRequest>
    {
        public UpdateProductPriceValidator()
        {

            RuleFor(x => x.Price)
                .GreaterThan(0)
                    .WithMessage("Price must be greater than zero");
        }
    }
}

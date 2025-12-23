using Application.Services.Sales.Models.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Sales.Validators
{
    public class CreateSaleDetailValidator : AbstractValidator<CreateDetailRequest>
    {
        public CreateSaleDetailValidator()
        {
            RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("ProductId must be a valid value");
           
            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero");

            
        }
    }
}

using Application.Services.Products.Models.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required")
            .MaximumLength(100).WithMessage("Product name must not exceed 100 characters")
            .Must(name => !string.IsNullOrWhiteSpace(name))
                .WithMessage("Product name cannot be empty or whitespace");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MinimumLength(5).WithMessage("Description must have at least 5 characters")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters")
                .Must(desc => !string.IsNullOrWhiteSpace(desc))
                    .WithMessage("Description cannot be empty or whitespace");

            
            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Stock cannot be negative");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                    .WithMessage("CategoryId must be a valid value");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                    .WithMessage("Price must be greater than zero");
        }
    }
}

using Application.Services.Categories.Features;
using Application.Services.Categories.Models.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Categories.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryForRequest>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                    .WithMessage("Category name is required")
                .MaximumLength(40)
                    .WithMessage("Category name must not exceed 40 characters");

        }
    }
}

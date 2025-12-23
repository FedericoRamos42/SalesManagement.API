using Application.Services.Customers.Models.Request;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Customers.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerForRequest>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters")
                .Must(name => !string.IsNullOrWhiteSpace(name))
                    .WithMessage("Name cannot be empty or whitespace");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email format is invalid")
                .MaximumLength(150).WithMessage("Email must not exceed 150 characters");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required")
                .MinimumLength(8).WithMessage("Phone number is too short")
                .MaximumLength(20).WithMessage("Phone number is too long")
                .Matches(@"^[0-9+\-\s]+$")
                    .WithMessage("Phone number format is invalid");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required")
                .MinimumLength(5).WithMessage("Address must have at least 5 characters")
                .MaximumLength(200).WithMessage("Address must not exceed 200 characters")
                .Must(address => !string.IsNullOrWhiteSpace(address))
                    .WithMessage("Address cannot be empty or whitespace");
        }

    }
}

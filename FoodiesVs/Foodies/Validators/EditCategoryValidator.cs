using FluentValidation;
using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Validators
{
    public class EditCategoryValidator : AbstractValidator<Category>
    {
        public EditCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Please fill in a name.");
            RuleFor(x => x.Name)
                .Length(5, 50)
                .WithMessage("Name must be between 5 and 50 characters.");
        }
    }
}

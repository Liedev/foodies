using FluentValidation;
using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Validators
{
    public class UnitValidator : AbstractValidator<Models.Unit>
    {
        public UnitValidator(IEnumerable<Unit> units)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("A name must be filled in.");
            RuleFor(x => x.Name)
                .Length(0, 20)
                .WithMessage("A unit name can not be more then 20 characters.");
            RuleFor(x => x.Name)
                .IsUnique(units)
                .WithMessage("Level name is already used");
        }

    }
}

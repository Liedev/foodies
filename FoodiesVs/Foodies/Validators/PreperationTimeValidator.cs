using FluentValidation;
using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Validators
{
    public class PreperationTimeValidator : AbstractValidator<PreperationTime>
    {
        public PreperationTimeValidator(IEnumerable<PreperationTime> preperationTimes)
        {
            RuleFor(x => x.RangeMinutes)
                .NotEmpty()
                .WithMessage("Please insert how long a meal could take.");
            RuleFor(x => x.RangeMinutes)
                .IsUnique(preperationTimes)
                .WithMessage("Level name is already used");
        }
    }
}

using FluentValidation;
using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Validators
{
    public class LevelPreperationValidator: AbstractValidator<LevelPreperation>
    {
        public LevelPreperationValidator(IEnumerable<LevelPreperation> levelPreperations)
        {
            RuleFor(x => x.Level)
                .NotEmpty()
                .WithMessage("The level must be filled in.");
            RuleFor(x => x.Level)
                .Length(3,30)
                .WithMessage("Level length must be between 3 and 30 characters");
            RuleFor(x => x.Level)
                .IsUnique(levelPreperations)
                .WithMessage("Level name is already used");
        }
    }
}

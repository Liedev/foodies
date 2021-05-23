using FluentValidation;
using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Validators
{
    public class MealIngredientValidator : AbstractValidator<MealIngredient>
    {
        public MealIngredientValidator()
        {
            RuleFor(x => x.MealId)
                .NotNull()
                .WithMessage("Could not find the meal where you are linking to");
            RuleFor(x => x.IngredientId)
                .NotNull()
                .WithMessage("Could not find your ingredient");
            RuleFor(x => x.Amount)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Please fill in an amount greater then 0");
            RuleFor(x => x.UnitId)
                .NotNull()
                .WithMessage("could not find the unit measurements");                
        }
    }
}

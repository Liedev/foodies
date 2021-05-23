using FluentValidation;
using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Validators
{
    public class MealValidator : AbstractValidator<Meal>
    {
        public MealValidator(IEnumerable<Meal> meals)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Fill in a name");
            RuleFor(x => x.Name)
                .IsUnique(meals)
                .WithMessage("Name already exists");
            RuleFor(x => x.ShortDiscription)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Fill in a short discription under 200 characters");
            RuleFor(x => x.PreperationDiscribtion)
                .NotEmpty()
                .WithMessage("Fill in a preperation discribtion");
            RuleFor(x => x.NumberOfPeople)
                .GreaterThan(0)
                .WithMessage("You have deleted a person from existence, stay positive in your numbers");
            RuleFor(x => x.EndUserId)
                .NotNull()
                .WithMessage("Could not find your Identification, try again later");
            RuleFor(x => x.PictureMeal)
                .NotNull()
                .WithMessage("Image could not be converted, try again later");
        }
    }
}

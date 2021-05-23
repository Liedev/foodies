using FluentValidation;
using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Validators
{
    public class EditIngredientValidator : AbstractValidator<Ingredient>
    {
        public EditIngredientValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Fill in name");
            RuleFor(x => x.Name)
                    .Length(3, 150)
                    .WithMessage("Name must be between 3-150 characters");
            RuleFor(x => x.EnergyKcal)
                    .NotNull()
                    .WithMessage("Fill in EnergyKcal.");
            RuleFor(x => x.EnergyKcal)
                    .GreaterThan(-1)
                    .WithMessage("EnergyKcal must be greater or the same as 0");
            RuleFor(x => x.EnergyKj)
                    .GreaterThan(-1)
                    .NotNull()
                    .When(x => x.EnergyKj != null)
                    .WithMessage("EnergyKcal must be greater or the same as 0");
            RuleFor(x => x.Water)
                    .GreaterThan(-1)
                    .NotNull()
                    .When(x => x.Water != null)
                    .WithMessage("Water volume must be greater or the same as 0");
            RuleFor(x => x.EggWhite)
                    .GreaterThan(-1)
                    .NotNull()
                    .When(x => x.EggWhite != null)
                    .WithMessage("Number of eggwhites must be greater or the same as 0");
            RuleFor(x => x.Carbohydrates)
                    .GreaterThan(-1)
                    .NotNull()
                    .When(x => x.Carbohydrates != null)
                    .WithMessage("Carbohydrates must be greater or the same as 0");
            RuleFor(x => x.Sugar)
                    .GreaterThan(-1)
                    .NotNull()
                    .When(x => x.Sugar != null)
                    .WithMessage("Sugar must be greater or the same as 0");
            RuleFor(x => x.Fat)
                    .GreaterThan(-1)
                    .NotNull()
                    .When(x => x.Fat != null)
                    .WithMessage("Fat must be greater or the same as 0");
            RuleFor(x => x.SaturatedFat)
                    .GreaterThan(-1)
                    .NotNull()
                    .When(x => x.SaturatedFat != null)
                    .WithMessage("Saturated fat must be greater or the same as 0");
            RuleFor(x => x.SingleSaturatedFat)
                    .GreaterThan(-1)
                    .NotNull()
                    .When(x => x.SingleSaturatedFat != null)
                    .WithMessage("Single saturated fat must be greater or the same as 0");
            RuleFor(x => x.MultiSaturatedFat)
                    .GreaterThan(-1)
                    .NotNull()
                    .When(x => x.MultiSaturatedFat != null)
                    .WithMessage("MultiSaturated fat must be greater or the same as 0");
            RuleFor(x => x.Cholesterol)
                .GreaterThan(-1)
                .NotNull()
                .When(x => x.Cholesterol != null)
                .WithMessage("Cholesterol must be greater or the same as 0");
            RuleFor(x => x.Fiber)
                .GreaterThan(-1)
                .NotNull()
                .When(x => x.Fiber != null)
                .WithMessage("Fiber must be greater or the same as 0");
        }
    }
}

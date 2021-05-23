using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Validators
{
    public static class DefaultValidatorOptions
    {
        public static IRuleBuilderOptions<TItem, TProperty> IsUnique<TItem, TProperty>(
                this IRuleBuilder<TItem, TProperty> ruleBuilder, IEnumerable<TItem> items)
                where TItem : class
        {
            return ruleBuilder.SetValidator(new UniqueValidator<TItem>(items));
        }
    }
}

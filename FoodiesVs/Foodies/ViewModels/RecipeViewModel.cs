using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.ViewModels
{
    public class RecipeViewModel
    {
        public Meal Meal { get; set; }
        public List<MealIngredient> MealIngredients { get; set; }
    }
}

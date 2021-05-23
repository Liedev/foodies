using Foodies.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.ViewModels
{
    public class CreateMealIngredientViewModel
    {
        public MealIngredient MealIngredient { get; set; }
        public SelectList Meals { get; set; }
        public SelectList Ingredients { get; set; }
        public SelectList Units { get; set; }
    }
}

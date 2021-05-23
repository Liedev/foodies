using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.ViewModels
{
    public class IndexIngredientViewModel
    {
        public string IngredientSearch { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}

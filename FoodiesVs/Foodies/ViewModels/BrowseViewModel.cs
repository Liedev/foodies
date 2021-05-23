using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.ViewModels
{
    public class BrowseViewModel
    {
        public string MealSearch { get; set; }
        public List<Meal> Meals { get; set; }
    }
}

using Foodies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.ViewModels
{
    public class CreateMealViewModel
    {
        public string ErrorMessage { get; set; }
        public Meal Meal { get; set; }
        public SelectList LevelPreperations { get; set; }
        public SelectList PreperationTimes { get; set; }
        public IEnumerable<SelectListItem> Category { get; set; }
        public IEnumerable<int> SelectedCategories { get; set; }
        public IFormFile MealImage { get; set; }
    }
}

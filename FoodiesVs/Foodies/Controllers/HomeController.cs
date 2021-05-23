using Foodies.Data;
using Foodies.Models;
using Foodies.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Foodies.Controllers
{
    public class HomeController : Controller
    {
        private readonly FoodiesContext _context;

        public HomeController(FoodiesContext context)
        {
            _context = context;
        }

        // GET: Meals
        public async Task<IActionResult> Index()
        {
            MealViewModel mealViewModel = new MealViewModel();
            mealViewModel.Meals = await _context.Meals.Include(m => m.MealIngredients).ToListAsync();
            return View(mealViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}

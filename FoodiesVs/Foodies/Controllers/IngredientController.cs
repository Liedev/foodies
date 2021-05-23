using Foodies.Data;
using Foodies.Models;
using Foodies.Validators;
using Foodies.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IngredientController : Controller
    {
        private readonly FoodiesContext _context;

        public IngredientController(FoodiesContext context)
        {
            _context = context;
        }

        // GET: Ingredient
        public async Task<IActionResult> Index()
        {
            IndexIngredientViewModel indexIngredientViewModel = new IndexIngredientViewModel();
            indexIngredientViewModel.Ingredients = await _context.Ingredients.ToListAsync();
            return View(indexIngredientViewModel);
        }

        //GET: Searchfilter

        public async Task<IActionResult> Search(IndexIngredientViewModel indexIngredientViewModel)
        {
            if (!string.IsNullOrEmpty(indexIngredientViewModel.IngredientSearch))
            {
                indexIngredientViewModel.Ingredients = await _context.Ingredients
                    .Where(c => c.Name.Contains(indexIngredientViewModel.IngredientSearch)).ToListAsync();
            }
            else
            {
                indexIngredientViewModel.Ingredients = await _context.Ingredients.ToListAsync();
            }
            return View("Index", indexIngredientViewModel);
        }

        // GET: Ingredient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var ingredient = await _context.Ingredients
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(ingredient);
        }

        // GET: Ingredient/Create
        public IActionResult Create()
        {
            IngredientViewModel createIngredientViewModel = new IngredientViewModel();
            createIngredientViewModel.Ingredient = new Ingredient();
            return View(createIngredientViewModel);
        }

        // POST: Ingredient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IngredientViewModel createIngredientViewModel)
        {
            var validator = new IngredientValidator(_context.Ingredients);
            var result = validator.Validate(createIngredientViewModel.Ingredient);
            if (result.IsValid)
            {
                _context.Add(createIngredientViewModel.Ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.ErrorMessage);
                }
            }
            return View(createIngredientViewModel);
        }

        // GET: Ingredient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return RedirectToAction("Error", "Home");
            }
            IngredientViewModel ingredientViewModel = new IngredientViewModel();
            ingredientViewModel.Ingredient = ingredient;
            return View(ingredientViewModel);
        }

        // POST: Ingredient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IngredientViewModel editIngredientViewModel)
        {
            if (id != editIngredientViewModel.Ingredient.IngredientId)
            {
                return RedirectToAction("Error", "Home");
            }
            Ingredient checkIngredientName = await _context.Ingredients.SingleOrDefaultAsync(x => x.Name == editIngredientViewModel.Ingredient.Name && x.IngredientId == editIngredientViewModel.Ingredient.IngredientId);
            var result = new FluentValidation.Results.ValidationResult();//Bypass the name validator and didn't know how to do it any other way
            if (checkIngredientName != null)
            {
               var validator = new EditIngredientValidator();
               result = validator.Validate(editIngredientViewModel.Ingredient);
            }
            else
            {
               var validator = new IngredientValidator(_context.Ingredients);
               result = validator.Validate(editIngredientViewModel.Ingredient);
            }            
            if (result.IsValid)
            {
                Ingredient ingredient = await _context.Ingredients.SingleOrDefaultAsync(x => x.IngredientId == id);
                if (ingredient != null)
                {
                    ingredient.Name = editIngredientViewModel.Ingredient.Name;
                    ingredient.EnergyKcal = editIngredientViewModel.Ingredient.EnergyKcal;
                    ingredient.EnergyKj = editIngredientViewModel.Ingredient.EnergyKj;
                    ingredient.Water = editIngredientViewModel.Ingredient.Water;
                    ingredient.EggWhite = editIngredientViewModel.Ingredient.EggWhite;
                    ingredient.Carbohydrates = editIngredientViewModel.Ingredient.Carbohydrates;
                    ingredient.Sugar = editIngredientViewModel.Ingredient.Sugar;
                    ingredient.Fat = editIngredientViewModel.Ingredient.Fat;
                    ingredient.SaturatedFat = editIngredientViewModel.Ingredient.SaturatedFat;
                    ingredient.SingleSaturatedFat = editIngredientViewModel.Ingredient.SingleSaturatedFat;
                    ingredient.MultiSaturatedFat = editIngredientViewModel.Ingredient.MultiSaturatedFat;
                    ingredient.Cholesterol = editIngredientViewModel.Ingredient.Cholesterol;
                    ingredient.Fiber = editIngredientViewModel.Ingredient.Fiber;
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Could not edit the ingredient. Try again later.");
                }                
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.ErrorMessage);
                }
            }
            return View(editIngredientViewModel);
        }

        // GET: Ingredient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var ingredient = await _context.Ingredients
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(ingredient);
        }

        // POST: Ingredient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.IngredientId == id);
        }
    }
}
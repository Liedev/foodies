using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Foodies.Data;
using Foodies.Models;
using Microsoft.AspNetCore.Authorization;
using Foodies.ViewModels;
using Foodies.Validators;

namespace Foodies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MealIngredientController : Controller
    {
        private readonly FoodiesContext _context;

        public MealIngredientController(FoodiesContext context)
        {
            _context = context;
        }

        // GET: MealIngredient
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {            
            var foodiesContext = _context.MealIngredients.Include(m => m.Ingredient).Include(m => m.Meal).Include(m => m.Unit);
            return View(await foodiesContext.ToListAsync());
        }

        // GET: MealIngredient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var mealIngredient = await _context.MealIngredients
                .Include(m => m.Ingredient)
                .Include(m => m.Meal)
                .Include(m => m.Unit)
                .FirstOrDefaultAsync(m => m.MealIngredientId == id);
            if (mealIngredient == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(mealIngredient);
        }

        // GET: MealIngredient/Create
        public IActionResult Create(int id)
        {
            MealIngredientViewModel mealIngredientViewModel = new MealIngredientViewModel();
            mealIngredientViewModel.MealIngredient = new MealIngredient();
            mealIngredientViewModel.MealIngredient.MealId = id;
            mealIngredientViewModel.MealIngredients = new List<MealIngredient>(_context.MealIngredients
                .Where(x => x.MealId == id).Include(x => x.Meal));
            mealIngredientViewModel.Ingredients = new SelectList(_context.Ingredients, "IngredientId", "Name");
            mealIngredientViewModel.Units = new SelectList(_context.Units, "UnitId", "Name");
            return View(mealIngredientViewModel);
        }

        // POST: MealIngredient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MealIngredientViewModel mealIngredientViewModel)
        {
            var validator = new MealIngredientValidator();
            var result = validator.Validate(mealIngredientViewModel.MealIngredient);
            List<MealIngredient> mealIngredientsCheck = new List<MealIngredient>(_context.MealIngredients
                .Include(x => x.Ingredient)
                .Where(x => x.MealId == mealIngredientViewModel.MealIngredient.MealId));
            if (mealIngredientsCheck.Where(x => x.Ingredient.IngredientId == mealIngredientViewModel.MealIngredient.IngredientId).Count() > 0)
            {
                ModelState.AddModelError(string.Empty,"The meal already contains the meal ingredient");
            }
            if (result.IsValid && ModelState.IsValid)
            {
                _context.Add(mealIngredientViewModel.MealIngredient);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", mealIngredientViewModel.MealId);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.ErrorMessage);
                }
            }
            mealIngredientViewModel.MealIngredients = new List<MealIngredient>(_context.MealIngredients.Where(x => x.MealId == mealIngredientViewModel.MealIngredient.MealId).Include(x => x.Meal));
            mealIngredientViewModel.Ingredients = new SelectList(_context.Ingredients, "IngredientId", "Name", mealIngredientViewModel.MealIngredient.IngredientId);
            mealIngredientViewModel.Units = new SelectList(_context.Units, "UnitId", "Name", mealIngredientViewModel.MealIngredient.UnitId);
            return View(mealIngredientViewModel);
        }

        // GET: MealIngredient/Edit/5
        public async Task<IActionResult> Edit(int? id, MealIngredientViewModel mealIngredientViewModel)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var mealIngredient = await _context.MealIngredients.FindAsync(id);
            if (mealIngredient == null)
            {
                return RedirectToAction("Error", "Home");
            }
            mealIngredientViewModel.MealIngredient = mealIngredient;
            mealIngredientViewModel.Ingredients = new SelectList(_context.Ingredients, "IngredientId", "Name", mealIngredientViewModel.MealIngredient.MealIngredientId);
            mealIngredientViewModel.Units = new SelectList(_context.Units, "UnitId", "Name", mealIngredientViewModel.MealIngredient.UnitId);
            return View(mealIngredientViewModel);
        }

        // POST: MealIngredient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MealIngredientViewModel mealIngredientViewModel)
        {
            if (id != mealIngredientViewModel.MealIngredient.MealIngredientId)
            {
                return RedirectToAction("Error", "Home");
            }

            if (ModelState.IsValid)
            {
                _context.Update(mealIngredientViewModel.MealIngredient);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", new { id = mealIngredientViewModel.MealIngredient.MealId});
            }
            mealIngredientViewModel.Ingredients = new SelectList(_context.Ingredients, "IngredientId", "Name", mealIngredientViewModel.MealIngredient.MealIngredientId);
            mealIngredientViewModel.Units = new SelectList(_context.Units, "UnitId", "Name", mealIngredientViewModel.MealIngredient.UnitId);
            return View(mealIngredientViewModel);
        }

        // GET: MealIngredient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            var mealIngredient = await _context.MealIngredients
                .Include(m => m.Ingredient)
                .Include(m => m.Meal)
                .Include(m => m.Unit)
                .FirstOrDefaultAsync(m => m.MealIngredientId == id);
            if (mealIngredient == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(mealIngredient);
        }

        // POST: MealIngredient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mealIngredient = await _context.MealIngredients.FindAsync(id);
            int mealId = mealIngredient.MealId;
            _context.MealIngredients.Remove(mealIngredient);
            await _context.SaveChangesAsync();
            return RedirectToAction("Create", new { id = mealIngredient.MealId });
        }

        private bool MealIngredientExists(int id)
        {
            return _context.MealIngredients.Any(e => e.MealIngredientId == id);
        }
    }
}

using Foodies.Areas.Identity.Data;
using Foodies.Data;
using Foodies.Models;
using Foodies.Validators;
using Foodies.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MealController : Controller
    {
        private readonly FoodiesContext _context;
        private UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        //https://www.c-sharpcorner.com/article/upload-and-display-image-in-asp-net-core-3-1/
        public MealController(FoodiesContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Meal
        public async Task<IActionResult> Index()
        {
            var foodiesContext = _context.Meals.Include(m => m.LevelPreperation).Include(m => m.PreperationTime);
            return View(await foodiesContext.ToListAsync());
        }

        // GET: Meal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var meal = await _context.Meals
                .Include(m => m.LevelPreperation)
                .Include(m => m.PreperationTime)
                .FirstOrDefaultAsync(m => m.MealId == id);
            if (meal == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(meal);
        }

        // GET: Meal/Create
        public IActionResult Create()
        {
            CreateMealViewModel model = new CreateMealViewModel();
            model.Meal = new Meal();
            model.LevelPreperations = new SelectList(_context.LevelPreperations, "LevelPreperationId", "Level");
            model.PreperationTimes = new SelectList(_context.PreperationTimes, "PreperationTimeId", "RangeMinutes");
            model.Category = new SelectList(_context.Categories, "CategoryId", "Name");
            model.SelectedCategories = new List<int>();
            return View(model);
        }

        // POST: Meal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMealViewModel model)
        {
            var userId = _userManager.GetUserId(User);
            EndUser endUser = await _context.EndUsers.FirstOrDefaultAsync(x => x.ApplicationUserId == userId);
            string uploadedFile = UploadedFile(model.MealImage);
            if (string.IsNullOrEmpty(uploadedFile))
            {
                ModelState.AddModelError(string.Empty, "Image is not selected");
            }
            if (endUser != null && ModelState.IsValid)
            {
                model.Meal.EndUserId = endUser.EndUserId;
                model.Meal.PictureMeal = uploadedFile;
                var validator = new MealValidator(_context.Meals);
                var result = validator.Validate(model.Meal);
                if (result.IsValid)
                {
                    if (model.SelectedCategories != null)
                    {
                        List<MealCategory> newCategories = new List<MealCategory>();
                        foreach (int CategoryId in model.SelectedCategories)
                        {
                            newCategories.Add(new MealCategory
                            {
                                MealId = model.Meal.MealId,
                                CategoryId = CategoryId
                            });
                        }
                        _context.Add(model.Meal);
                        await _context.SaveChangesAsync();
                        Meal meal = await _context.Meals
                            .Include(mc => mc.MealCategories)
                            .SingleOrDefaultAsync(meal => meal.MealId == model.Meal.MealId);
                        meal.MealCategories.AddRange(newCategories);
                        _context.Update(meal);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Select at least one category!");
                    }
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.ErrorMessage);
                    }
                }
            }
            model.LevelPreperations = new SelectList(_context.LevelPreperations, "LevelPreperationId", "Level", model.Meal.LevelPreperationId);
            model.PreperationTimes = new SelectList(_context.PreperationTimes, "PreperationTimeId", "RangeMinutes", model.Meal.PreperationTimeId);
            model.Category = new SelectList(_context.Categories, "CategoryId", "Name");
            model.SelectedCategories = new List<int>();
            return View(model);
        }
        private string UploadedFile(IFormFile formFile)
        {
            string uniqueFileName = null;

            if (formFile != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "assets");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: Meal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Meal meal = await _context.Meals.Include(c => c.MealCategories).SingleOrDefaultAsync(x => x.MealId == id);
            if (meal == null)
            {
                return RedirectToAction("Error", "Home");
            }
            EditMealViewModel model = new EditMealViewModel();
            model.Meal = meal;
            model.LevelPreperations = new SelectList(_context.LevelPreperations, "LevelPreperationId", "Level", model.Meal.LevelPreperationId);
            model.PreperationTimes = new SelectList(_context.PreperationTimes, "PreperationTimeId", "RangeMinutes", model.Meal.PreperationTimeId);
            model.Category = new SelectList(_context.Categories, "CategoryId", "Name");
            model.SelectedCategories = meal.MealCategories.Select(mc => mc.CategoryId); 
            return View(model);
        }

        // POST: Meal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditMealViewModel model)
        {
            if (id != model.Meal.MealId)
            {
                return RedirectToAction("Error", "Home");
            }
            Meal meal = await _context.Meals.Include(c => c.MealCategories).SingleOrDefaultAsync(x => x.MealId == id);
            if (meal != null)
            {
                meal.Name = model.Meal.Name;
                meal.ShortDiscription = model.Meal.ShortDiscription;
                meal.PreperationDiscribtion = model.Meal.PreperationDiscribtion;
                meal.NumberOfPeople = model.Meal.NumberOfPeople;
                if (meal.PictureMeal != model.Meal.PictureMeal)
                {
                    meal.PictureMeal = UploadedFile(model.MealImage);
                }
                Meal checkMealName = await _context.Meals.SingleOrDefaultAsync(x => x.Name == model.Meal.Name && x.MealId == model.Meal.MealId);
                var result = new FluentValidation.Results.ValidationResult();//Bypass the name validator and didn't know how to do it any other way
                if (checkMealName != null)
                {
                    var validator = new EditMealValidator();
                    result = validator.Validate(model.Meal);
                }
                else
                {
                    var validator = new MealValidator(_context.Meals);
                    result = validator.Validate(model.Meal);
                }                
                if (result.IsValid)
                {
                    if (model.SelectedCategories != null)
                    {
                        List<MealCategory> newCategories = new List<MealCategory>();
                        foreach (int CategoryId in model.SelectedCategories)
                        {
                            newCategories.Add(new MealCategory
                            {
                                MealId = model.Meal.MealId,
                                CategoryId = CategoryId
                            });
                        }
                        meal.MealCategories.RemoveAll(mc => !newCategories.Contains(mc));
                        meal.MealCategories.AddRange(newCategories.Where(nc => !meal.MealCategories.Contains(nc)));
                        _context.Update(meal);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        model.ErrorMessage += "Select at least one categorie";
                    }
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.ErrorMessage);
                    }
                }
            }
            else
            {
                model.ErrorMessage += "Select at least one categorie";
            }
                return View(model);
        }

        // GET: Meal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Meal meal = await _context.Meals
                .Include(m => m.LevelPreperation)
                .Include(m => m.PreperationTime)
                .FirstOrDefaultAsync(m => m.MealId == id);
            if (meal == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(meal);
        }

        // POST: Meal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Meal meal = await _context.Meals.FindAsync(id);
            System.IO.File.Delete(Path.Combine(Environment.CurrentDirectory, "wwwroot", "assets", meal.PictureMeal));
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealExists(int id)
        {
            return _context.Meals.Any(e => e.MealId == id);
        }

        //Get: Meal/Recipe/id
        [AllowAnonymous]
        public async Task<IActionResult> Recipe(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            RecipeViewModel recipeViewModel = new RecipeViewModel();
            recipeViewModel.Meal = await _context.Meals
                 .Include(m => m.LevelPreperation)
                 .Include(m => m.PreperationTime)
                 .FirstOrDefaultAsync(m => m.MealId == id);
            recipeViewModel.MealIngredients = new List<MealIngredient>(await _context.MealIngredients
                .Include(mi => mi.Ingredient)
                .Include(mi => mi.Unit)
                .Where(mi => mi.MealId == id)
                .ToListAsync());
            return View(recipeViewModel);
        }
    }
}
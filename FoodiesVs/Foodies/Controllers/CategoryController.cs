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
using Foodies.Validators;
using Foodies.ViewModels;

namespace Foodies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        //Chose to implement the Head Categories in the database. All sub-categories must be created here
        private readonly FoodiesContext _context;

        public CategoryController(FoodiesContext context)
        {
            _context = context;
        }

        // GET: Categorie
        public async Task<IActionResult> Index()
        {
            IndexCategoryViewModel indexCategoryViewModel = new IndexCategoryViewModel();
            indexCategoryViewModel.Categories = await _context.Categories.Include(c => c.Parent).Where(c => c.ParentId != null).ToListAsync();
            return View(indexCategoryViewModel);
        }

        //GET: Searchfilter

        public async Task<IActionResult> Search(IndexCategoryViewModel indexCategoryViewModel)
        {
            if (!string.IsNullOrEmpty(indexCategoryViewModel.CategorySearch))
            {
                indexCategoryViewModel.Categories = await _context.Categories.Include(c => c.Parent)
                    .Where(c => c.Name.Contains(indexCategoryViewModel.CategorySearch))
                    .Where(c => c.ParentId != null).ToListAsync();
            }
            else
            {
                indexCategoryViewModel.Categories = await _context.Categories.Include(c => c.Parent).ToListAsync();
            }
            return View("Index", indexCategoryViewModel);
        }

        // GET: Categorie/Details/5
        public async Task<IActionResult> Details(int? id)
        {            
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var category = await _context.Categories
                .Include(c => c.Parent)
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categorie/Create
        public IActionResult Create()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Category = new Category();
            categoryViewModel.Parents = new SelectList(_context.Categories.Where(x => x.ParentId == null), "CategoryId", "Name");
            return View(categoryViewModel);
        }

        // POST: Categorie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
        {
            var validator = new CategoryValidator(_context.Categories);
            var result = validator.Validate(categoryViewModel.Category);
            if (result.IsValid)
            {
                _context.Add(categoryViewModel.Category);
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
            categoryViewModel.Parents = new SelectList(_context.Categories.Where(x => x.ParentId == null), "CategoryId", "Name");
            return View(categoryViewModel);
        }

        // GET: Categorie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return RedirectToAction("Error", "Home");
            }
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Category = category;
            categoryViewModel.Parents = new SelectList(_context.Categories.Where(x => x.ParentId == null), "CategoryId", "Name", category.ParentId);
            return View(categoryViewModel);
        }

        // POST: Categorie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,CategoryViewModel categoryViewModel)
        {
            if (id != categoryViewModel.Category.CategoryId)
            {
                return RedirectToAction("Error", "Home");
            }
            Category checkCategoryName = await _context.Categories.SingleOrDefaultAsync(x => x.Name == categoryViewModel.Category.Name && x.CategoryId == categoryViewModel.Category.CategoryId);
            var result = new FluentValidation.Results.ValidationResult();//Bypass the name validator and didn't know how to do it any other way
            if (checkCategoryName != null)
            {
                var validator = new EditCategoryValidator();
                result = validator.Validate(categoryViewModel.Category);
            }
            else
            {
                var validator = new CategoryValidator(_context.Categories);
                result = validator.Validate(categoryViewModel.Category);
            }
            if (result.IsValid)
            {

                    _context.Update(categoryViewModel.Category);
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
            categoryViewModel.Parents = new SelectList(_context.Categories.Where(x => x.ParentId == null), "CategoryId", "Name", categoryViewModel.Category.ParentId);
            return View(categoryViewModel);
        }

        // GET: Categorie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var category = await _context.Categories
                .Include(c => c.Parent)
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(category);
        }

        // POST: Categorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}

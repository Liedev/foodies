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

namespace Foodies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LevelPreperationController : Controller
    {
        private readonly FoodiesContext _context;

        public LevelPreperationController(FoodiesContext context)
        {
            _context = context;
        }

        // GET: LevelPreperation
        public async Task<IActionResult> Index()
        {
            return View(await _context.LevelPreperations.ToListAsync());
        }

        // GET: LevelPreperation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var levelPreperation = await _context.LevelPreperations
                .FirstOrDefaultAsync(m => m.LevelPreperationId == id);
            if (levelPreperation == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(levelPreperation);
        }

        // GET: LevelPreperation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LevelPreperation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LevelPreperationId,Level")] LevelPreperation levelPreperation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(levelPreperation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(levelPreperation);
        }

        // GET: LevelPreperation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var levelPreperation = await _context.LevelPreperations.FindAsync(id);
            if (levelPreperation == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(levelPreperation);
        }

        // POST: LevelPreperation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LevelPreperationId,Level")] LevelPreperation levelPreperation)
        {
            if (id != levelPreperation.LevelPreperationId)
            {
                return RedirectToAction("Error", "Home");
            }
            if (ModelState.IsValid)
            {
                _context.Update(levelPreperation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(levelPreperation);
        }

        // GET: LevelPreperation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var levelPreperation = await _context.LevelPreperations
                .FirstOrDefaultAsync(m => m.LevelPreperationId == id);
            if (levelPreperation == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(levelPreperation);
        }

        // POST: LevelPreperation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var levelPreperation = await _context.LevelPreperations.FindAsync(id);
            _context.LevelPreperations.Remove(levelPreperation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LevelPreperationExists(int id)
        {
            return _context.LevelPreperations.Any(e => e.LevelPreperationId == id);
        }
    }
}

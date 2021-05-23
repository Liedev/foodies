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
    public class UnitController : Controller
    {
        private readonly FoodiesContext _context;

        public UnitController(FoodiesContext context)
        {
            _context = context;
        }

        // GET: Unit
        public async Task<IActionResult> Index()
        {
            return View(await _context.Units.ToListAsync());
        }

        // GET: Unit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var unit = await _context.Units
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (unit == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(unit);
        }

        // GET: Unit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitId,Name")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unit);
        }

        // GET: Unit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var unit = await _context.Units.FindAsync(id);
            if (unit == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(unit);
        }

        // POST: Unit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnitId,Name")] Unit unit)
        {
            if (id != unit.UnitId)
            {
                return RedirectToAction("Error", "Home");
            }

            if (ModelState.IsValid)
            {
                _context.Update(unit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unit);
        }

        // GET: Unit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var unit = await _context.Units
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (unit == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(unit);
        }

        // POST: Unit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unit = await _context.Units.FindAsync(id);
            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitExists(int id)
        {
            return _context.Units.Any(e => e.UnitId == id);
        }
    }
}

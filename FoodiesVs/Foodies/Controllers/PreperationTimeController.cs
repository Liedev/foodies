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
    public class PreperationTimeController : Controller
    {
        private readonly FoodiesContext _context;

        public PreperationTimeController(FoodiesContext context)
        {
            _context = context;
        }

        // GET: PreperationTime
        public async Task<IActionResult> Index()
        {
            return View(await _context.PreperationTimes.ToListAsync());
        }

        // GET: PreperationTime/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var preperationTime = await _context.PreperationTimes
                .FirstOrDefaultAsync(m => m.PreperationTimeId == id);
            if (preperationTime == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(preperationTime);
        }

        // GET: PreperationTime/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PreperationTime/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PreperationTimeId,RangeMinutes")] PreperationTime preperationTime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preperationTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(preperationTime);
        }

        // GET: PreperationTime/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var preperationTime = await _context.PreperationTimes.FindAsync(id);
            if (preperationTime == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(preperationTime);
        }

        // POST: PreperationTime/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PreperationTimeId,RangeMinutes")] PreperationTime preperationTime)
        {
            if (id != preperationTime.PreperationTimeId)
            {
                return RedirectToAction("Error", "Home");
            }

            if (ModelState.IsValid)
            {
                _context.Update(preperationTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(preperationTime);
        }

        // GET: PreperationTime/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var preperationTime = await _context.PreperationTimes
                .FirstOrDefaultAsync(m => m.PreperationTimeId == id);
            if (preperationTime == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(preperationTime);
        }

        // POST: PreperationTime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preperationTime = await _context.PreperationTimes.FindAsync(id);
            _context.PreperationTimes.Remove(preperationTime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreperationTimeExists(int id)
        {
            return _context.PreperationTimes.Any(e => e.PreperationTimeId == id);
        }
    }
}

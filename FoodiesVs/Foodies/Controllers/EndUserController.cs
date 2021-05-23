using Foodies.Data;
using Foodies.Models;
using Foodies.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Controllers
{
    [Authorize]
    public class EndUserController : Controller
    {
        private readonly FoodiesContext _context;

        public EndUserController(FoodiesContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Browse()
        {
            BrowseViewModel browseViewModel = new BrowseViewModel();
            browseViewModel.Meals = await _context.Meals
                .Include(m => m.MealCategories)
                .Include(m =>m.MealIngredients)
                .ToListAsync();
            return View(browseViewModel);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Search(BrowseViewModel browseViewModel)
        {
            if (!string.IsNullOrEmpty(browseViewModel.MealSearch))
            {
                browseViewModel.Meals = await _context.Meals
                    .Include(m => m.MealCategories)
                    .Include(m => m.MealIngredients)
                    .Where(c => c.Name.Contains(browseViewModel.MealSearch)).ToListAsync();
            }
            else
            {
                browseViewModel.Meals = await _context.Meals
                    .Include(m => m.MealCategories)
                    .Include(m => m.MealIngredients)
                    .ToListAsync();
            }
            return View("Browse", browseViewModel);
        }
        [AllowAnonymous]
        public IActionResult Foodies()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult TermsOfService()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
        // GET: EndUser
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.EndUsers.ToListAsync());
        }

        // GET: EndUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var endUser = await _context.EndUsers
                .FirstOrDefaultAsync(m => m.EndUserId == id);
            if (endUser == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(endUser);
        }

        // GET: EndUser/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        // POST: EndUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EndUserId,Name,LastName,UserName,Email,PasswordHash,Avatar,ApplicationUserId")] EndUser endUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(endUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(endUser);
        }

        // GET: EndUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var endUser = await _context.EndUsers.FindAsync(id);
            if (endUser == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(endUser);
        }

        // POST: EndUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EndUserId,Name,LastName,UserName,Email,PasswordHash,Avatar,ApplicationUserId")] EndUser endUser)
        {
            if (id != endUser.EndUserId)
            {
                return RedirectToAction("Error", "Home");
            }

            if (ModelState.IsValid)
            {
                _context.Update(endUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(endUser);
        }

        // GET: EndUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var endUser = await _context.EndUsers
                .FirstOrDefaultAsync(m => m.EndUserId == id);
            if (endUser == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(endUser);
        }

        // POST: EndUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var endUser = await _context.EndUsers.FindAsync(id);
            _context.EndUsers.Remove(endUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EndUserExists(int id)
        {
            return _context.EndUsers.Any(e => e.EndUserId == id);
        }
    }
}

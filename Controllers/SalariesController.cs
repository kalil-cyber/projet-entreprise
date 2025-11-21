using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mac.Data;
using mac.Models;

namespace mac.Controllers
{
    public class SalariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _context.Salaries
                .Include(s => s.Departement)
                .OrderBy(s => s.Nom)
                .ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            ViewData["DepartementId"] = new SelectList(_context.Departements, "Id", "Nom");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Salarie salarie)
        {
            if (ModelState.IsValid)
            {
                _context.Salaries.Add(salarie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartementId"] = new SelectList(_context.Departements, "Id", "Nom", salarie.DepartementId);
            return View(salarie);
        }

        public async Task<IActionResult> Details(int id)
        {
            var salarie = await _context.Salaries
                .Include(s => s.Departement)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (salarie == null) return NotFound();
            return View(salarie);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var salarie = await _context.Salaries.FindAsync(id);
            if (salarie == null) return NotFound();
            ViewData["DepartementId"] = new SelectList(_context.Departements, "Id", "Nom", salarie.DepartementId);
            return View(salarie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Salarie salarie)
        {
            if (id != salarie.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salarie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Salaries.Any(e => e.Id == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartementId"] = new SelectList(_context.Departements, "Id", "Nom", salarie.DepartementId);
            return View(salarie);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var salarie = await _context.Salaries
                .Include(s => s.Departement)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (salarie == null) return NotFound();
            return View(salarie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salarie = await _context.Salaries.FindAsync(id);
            if (salarie != null)
            {
                _context.Salaries.Remove(salarie);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}


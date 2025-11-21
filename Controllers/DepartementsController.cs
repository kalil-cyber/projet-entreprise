using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mac.Data;
using mac.Models;

namespace mac.Controllers
{
    public class DepartementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _context.Departements
                .Include(d => d.Salaries)
                .OrderBy(d => d.Nom)
                .ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departement departement)
        {
            if (ModelState.IsValid)
            {
                _context.Departements.Add(departement);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Le département '{departement.Nom}' a été créé avec succès.";
                return RedirectToAction(nameof(Index));
            }
            return View(departement);
        }

        public async Task<IActionResult> Details(int id)
        {
            var departement = await _context.Departements
                .Include(d => d.Salaries)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (departement == null) return NotFound();
            return View(departement);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var departement = await _context.Departements.FindAsync(id);
            if (departement == null) return NotFound();
            return View(departement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Departement departement)
        {
            if (id != departement.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Departements.Any(e => e.Id == id)) return NotFound();
                    throw;
                }
                TempData["SuccessMessage"] = $"Le département '{departement.Nom}' a été modifié avec succès.";
                return RedirectToAction(nameof(Index));
            }
            return View(departement);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var departement = await _context.Departements
                .Include(d => d.Salaries)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (departement == null) return NotFound();
            return View(departement);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departement = await _context.Departements
                .Include(d => d.Salaries)
                .FirstOrDefaultAsync(d => d.Id == id);
            
            if (departement == null)
            {
                return NotFound();
            }

            // Empêcher la suppression si des salariés sont associés
            if (departement.Salaries.Any())
            {
                TempData["ErrorMessage"] = $"Impossible de supprimer le département '{departement.Nom}' car il contient {departement.Salaries.Count} salarié(s).";
                return RedirectToAction(nameof(Delete), new { id = id });
            }

            _context.Departements.Remove(departement);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Le département '{departement.Nom}' a été supprimé avec succès.";
            return RedirectToAction(nameof(Index));
        }
    }
}


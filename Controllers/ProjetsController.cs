using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mac.Data;
using mac.Models;

namespace mac.Controllers
{
    public class ProjetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _context.Projets.OrderBy(p => p.Id).ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Projet projet)
        {
            if (ModelState.IsValid)
            {
                _context.Projets.Add(projet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projet);
        }

        public async Task<IActionResult> Details(int id)
        {
            var projet = await _context.Projets.FindAsync(id);
            if (projet == null) return NotFound();
            return View(projet);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var projet = await _context.Projets.FindAsync(id);
            if (projet == null) return NotFound();
            return View(projet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Projet projet)
        {
            if (id != projet.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Projets.Any(e => e.Id == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projet);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var projet = await _context.Projets.FindAsync(id);
            if (projet == null) return NotFound();
            return View(projet);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projet = await _context.Projets.FindAsync(id);
            if (projet != null)
            {
                _context.Projets.Remove(projet);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}


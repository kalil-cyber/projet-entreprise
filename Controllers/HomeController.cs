using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mac.Data;
using mac.Models;

namespace mac.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var stats = new
            {
                TotalDepartements = await _context.Departements.CountAsync(),
                TotalSalaries = await _context.Salaries.CountAsync(),
                TotalProjets = await _context.Projets.CountAsync(),
                SalaireMoyen = await _context.Salaries.AnyAsync() 
                    ? await _context.Salaries.AverageAsync(s => (double)s.Salaire) 
                    : 0,
                ProjetsEnCours = await _context.Projets
                    .CountAsync(p => p.DateDebut <= DateTime.Now && p.DateFin >= DateTime.Now)
            };

            ViewBag.Stats = stats;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


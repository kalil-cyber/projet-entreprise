using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mac.Data;

namespace mac.Controllers.Api
{
    [ApiController]
    [Route("api/stats")]
    [Produces("application/json")]
    public class StatsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StatsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/stats
        [HttpGet]
        public async Task<ActionResult<object>> GetStats()
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
                    .CountAsync(p => p.DateDebut <= DateTime.Now && p.DateFin >= DateTime.Now),
                ProjetsTermines = await _context.Projets
                    .CountAsync(p => p.DateFin < DateTime.Now),
                ProjetsAVenir = await _context.Projets
                    .CountAsync(p => p.DateDebut > DateTime.Now),
                DepartementsAvecSalaries = await _context.Departements
                    .CountAsync(d => d.Salaries.Any())
            };

            return Ok(stats);
        }
    }
}


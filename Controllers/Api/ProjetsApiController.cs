using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mac.Data;
using mac.Models;

namespace mac.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProjetsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjetsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjetsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetProjets()
        {
            var projets = await _context.Projets
                .Select(p => new
                {
                    p.Id,
                    p.Nom,
                    p.Description,
                    DateDebut = p.DateDebut.ToString("yyyy-MM-dd"),
                    DateFin = p.DateFin.ToString("yyyy-MM-dd"),
                    DureeJours = (p.DateFin - p.DateDebut).Days,
                    Statut = p.DateDebut <= DateTime.Now && p.DateFin >= DateTime.Now ? "En cours" :
                             p.DateFin < DateTime.Now ? "Terminé" : "À venir",
                    p.CreatedAt,
                    p.UpdatedAt
                })
                .ToListAsync();

            return Ok(projets);
        }

        // GET: api/ProjetsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetProjet(int id)
        {
            var projet = await _context.Projets
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Nom,
                    p.Description,
                    DateDebut = p.DateDebut.ToString("yyyy-MM-dd"),
                    DateFin = p.DateFin.ToString("yyyy-MM-dd"),
                    DureeJours = (p.DateFin - p.DateDebut).Days,
                    Statut = p.DateDebut <= DateTime.Now && p.DateFin >= DateTime.Now ? "En cours" :
                             p.DateFin < DateTime.Now ? "Terminé" : "À venir",
                    p.CreatedAt,
                    p.UpdatedAt
                })
                .FirstOrDefaultAsync();

            if (projet == null)
            {
                return NotFound(new { message = "Projet non trouvé", id });
            }

            return Ok(projet);
        }
    }
}


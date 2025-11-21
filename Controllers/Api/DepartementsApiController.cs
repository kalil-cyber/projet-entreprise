using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mac.Data;
using mac.Models;

namespace mac.Controllers.Api
{
    [ApiController]
    [Route("api/departements")]
    [Produces("application/json")]
    public class DepartementsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartementsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DepartementsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetDepartements()
        {
            var departements = await _context.Departements
                .Include(d => d.Salaries)
                .Select(d => new
                {
                    d.Id,
                    d.Nom,
                    NombreSalaries = d.Salaries.Count,
                    d.CreatedAt,
                    d.UpdatedAt
                })
                .ToListAsync();

            return Ok(departements);
        }

        // GET: api/departements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetDepartement(int id)
        {
            var departement = await _context.Departements
                .Include(d => d.Salaries)
                .Where(d => d.Id == id)
                .Select(d => new
                {
                    d.Id,
                    d.Nom,
                    NombreSalaries = d.Salaries.Count,
                    Salaries = d.Salaries.Select(s => new
                    {
                        s.Id,
                        s.Nom,
                        s.Prenom,
                        s.Age,
                        s.Salaire
                    }),
                    d.CreatedAt,
                    d.UpdatedAt
                })
                .FirstOrDefaultAsync();

            if (departement == null)
            {
                return NotFound(new { message = "Département non trouvé", id });
            }

            return Ok(departement);
        }
    }
}


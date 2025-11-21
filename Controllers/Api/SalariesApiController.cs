using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mac.Data;
using mac.Models;

namespace mac.Controllers.Api
{
    [ApiController]
    [Route("api/salaries")]
    [Produces("application/json")]
    public class SalariesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SalariesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/salaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetSalaries()
        {
            var salaries = await _context.Salaries
                .Include(s => s.Departement)
                .Select(s => new
                {
                    s.Id,
                    s.Nom,
                    s.Prenom,
                    s.Age,
                    s.Salaire,
                    Departement = s.Departement != null ? new
                    {
                        s.Departement.Id,
                        s.Departement.Nom
                    } : null,
                    s.CreatedAt,
                    s.UpdatedAt
                })
                .ToListAsync();

            return Ok(salaries);
        }

        // GET: api/salaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetSalarie(int id)
        {
            var salarie = await _context.Salaries
                .Include(s => s.Departement)
                .Where(s => s.Id == id)
                .Select(s => new
                {
                    s.Id,
                    s.Nom,
                    s.Prenom,
                    s.Age,
                    s.Salaire,
                    Departement = s.Departement != null ? new
                    {
                        s.Departement.Id,
                        s.Departement.Nom
                    } : null,
                    s.CreatedAt,
                    s.UpdatedAt
                })
                .FirstOrDefaultAsync();

            if (salarie == null)
            {
                return NotFound(new { message = "Salarié non trouvé", id });
            }

            return Ok(salarie);
        }
    }
}


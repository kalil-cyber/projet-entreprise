using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mac.Data;

namespace mac.Controllers.Api
{
    [ApiController]
    [Route("api/test")]
    [Produces("application/json")]
    public class TestApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TestApiController> _logger;

        public TestApiController(ApplicationDbContext context, ILogger<TestApiController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetTest()
        {
            try
            {
                // Test de connexion à la base de données
                var canConnect = await _context.Database.CanConnectAsync();
                var departementsCount = await _context.Departements.CountAsync();
                var salariesCount = await _context.Salaries.CountAsync();
                var projetsCount = await _context.Projets.CountAsync();

                var result = new
                {
                    Server = "✅ OK - Serveur fonctionne",
                    Database = canConnect ? "✅ OK - Base de données connectée" : "❌ ERREUR - Impossible de se connecter",
                    Departements = departementsCount,
                    Salaries = salariesCount,
                    Projets = projetsCount,
                    DatabaseFile = "mac.db",
                    Timestamp = DateTime.Now
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors du test");
                return Ok(new
                {
                    Server = "✅ OK - Serveur fonctionne",
                    Database = $"❌ ERREUR - {ex.Message}",
                    Exception = ex.GetType().Name,
                    Timestamp = DateTime.Now
                });
            }
        }
    }
}


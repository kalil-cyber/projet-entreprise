using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mac.Data;

namespace mac.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TestController> _logger;

        public TestController(ApplicationDbContext context, ILogger<TestController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            object info;

            try
            {
                // Test de connexion à la base de données
                var canConnect = _context.Database.CanConnect();
                var departementsCount = _context.Departements.Count();
                var salariesCount = _context.Salaries.Count();
                var projetsCount = _context.Projets.Count();

                info = new
                {
                    Server = "✅ OK - Serveur fonctionne",
                    Database = canConnect ? "✅ OK - Base de données connectée" : "❌ ERREUR - Impossible de se connecter",
                    Departements = departementsCount,
                    Salaries = salariesCount,
                    Projets = projetsCount,
                    Timestamp = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors du test de la base de données");
                info = new
                {
                    Server = "✅ OK - Serveur fonctionne",
                    Database = $"❌ ERREUR - {ex.Message}",
                    Timestamp = DateTime.Now
                };
            }

            return Json(info);
        }
    }
}


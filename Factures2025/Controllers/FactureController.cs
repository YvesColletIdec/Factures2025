using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Factures2025.Controllers
{
    public class FactureController : Controller
    {
        private SqliteContext _context;
        public FactureController(SqliteContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            //récupère toutes les factures et les clients liés et les facturesarticles
            List<Facture> liste = _context.Factures
                .Include(f => f.NumClientNavigation)
                .Include(f => f.FactureArticles)
                .ToList();
            return View(liste);
        }
    }
}

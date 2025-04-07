using Factures2025.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Factures2025.Controllers
{
    public class MaisonController : Controller
    {
        private readonly ILogger<MaisonController> _logger;

        public MaisonController(ILogger<MaisonController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

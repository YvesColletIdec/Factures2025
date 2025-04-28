using Microsoft.AspNetCore.Mvc;

namespace Factures2025.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Affiche()
        {
            return View();
        }
    }
}

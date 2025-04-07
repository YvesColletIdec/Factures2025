using Microsoft.AspNetCore.Mvc;

namespace Factures2025.Controllers
{
    public class TestController : Controller
    {
        public IActionResult MaPage()
        {
            return View();
        }
    }
}

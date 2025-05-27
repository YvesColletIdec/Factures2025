using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Factures2025.Helpers;

namespace Factures2025.Controllers
{
    public class PrintController : Controller
    {
        SqliteContext _context;
        public PrintController(SqliteContext context) { 
            _context = context;
        }
        public IActionResult Print(int factureId)
        {
            Facture f = _context.Factures.Include(x => x.FactureArticles)
                .ThenInclude(x => x.NumArticleNavigation)
                .Include(x => x.NumClientNavigation)
                .FirstOrDefault(x => x.NumFacture == factureId);
            string physicalPath = Impression.CreateDocumentFromTemplateWithFormat(f, @"C:\adi\facture_template.docx");
            byte[] pdfBytes = System.IO.File.ReadAllBytes(physicalPath);
            MemoryStream ms = new MemoryStream(pdfBytes);
            return new FileStreamResult(ms, "application/pdf");
        }

    }
}

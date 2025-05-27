using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Factures2025.Controllers
{
    public class FactureController : Controller
    {
        private SqliteContext _context;
        public FactureController(SqliteContext context)
        {
            _context = context;
        }

        //[Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            //récupère toutes les factures et les clients liés et les facturesarticles
            List<Facture> liste = _context.Factures
                .Include(f => f.NumClientNavigation)
                .Include(f => f.FactureArticles)
                .ToList();
            return View(liste);
        }

        public bool CreateNewFacture(List<FactureArticle> LignesFacture, DateTime DateFacture, int ClientId, string NumeroFacture)
        {
            Facture facture = new Facture();
            facture.DateFacture = DateOnly.FromDateTime(DateFacture);
            facture.NumClient = ClientId;
            facture.FactureArticles = LignesFacture;
            facture.NumFacture = int.Parse(NumeroFacture);
            facture.NumVendeur = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            _context.Add(facture);
            _context.SaveChanges();
            return true;
        }

        public IActionResult Create()
        {
            Facture f = new Facture() { DateFacture = DateOnly.FromDateTime(DateTime.Now) };
            //création de la liste des clients
            List<SelectListItem> listClients = new List<SelectListItem>();
            foreach (Client c in _context.Clients)
            {
                f.NumClient = c.NumClient;
                f.NumClientNavigation = c;
                listClients.Add(new SelectListItem() { Text = c.Prenom + " " + c.Nom, Value = c.NumClient.ToString() });
            }
            ViewData["Clients"] = listClients;
            //transformation de la liste des articles en json pour javascript plus tard
            ViewBag.ArticlesJson = JsonConvert.SerializeObject(_context.Articles);
            return View(f);
        }
    }

}

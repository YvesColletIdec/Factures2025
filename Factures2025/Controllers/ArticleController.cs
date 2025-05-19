using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Factures2025.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly SqliteContext _monContext;
        public ArticleController(SqliteContext context)
        {
            _monContext = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<Article> maliste = _monContext.Articles.Include(a => a.Categorie).ToList();
            int nombreArticles = maliste.Count();
            ViewBag.nombre = nombreArticles;
            return View(maliste);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article art, string maValeur)
        {
            if (ModelState.IsValid)
            {
                _monContext.Articles.Add(art);
                _monContext.SaveChanges();
                return RedirectToAction("Index");
            } else
            {
                return View(art);
            }
                
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Article art = _monContext.Articles.Include(a => a.Categorie).
                FirstOrDefault(a => a.NumArticle == id);
            //récupère la liste de toutes les catégories
            List<Categorie> listeCat = _monContext.Categories.ToList();
            //liste qui va être passée à la vue
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (Categorie categorie in listeCat)
            {
                selectList.Add(new SelectListItem() { 
                    Text = $"{categorie.Nom} ({categorie.Id})",
                    Value = categorie.Id.ToString()
                });
            }   

            ViewBag.listeCategories = selectList;
            //art = _monContext.Articles.FirstOrDefault(a => a.NumArticle == id);
            return View(art);
        }

        [HttpPost]
        public IActionResult Edit(Article art)
        {
            _monContext.Articles.Update(art);
            _monContext.SaveChanges();
            TempData["ok"] = "l'article a été sauvé";
            TempData["ko"] = "zut...";
            return RedirectToAction("Index");
        }
    }
    }

using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Factures2025.Controllers
{
    public class ArticleController : Controller
    {
        private readonly SqliteContext _monContext;
        public ArticleController(SqliteContext context)
        {
            _monContext = context;
        }
        public IActionResult Index()
        {
            List<Article> maliste = _monContext.Articles.ToList();
            return View(maliste);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article art)
        {
            _monContext.Articles.Add(art);
            _monContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Article art = _monContext.Articles.Find(id);
            //art = _monContext.Articles.FirstOrDefault(a => a.NumArticle == id);
            return View(art);
        }

        [HttpPost]
        public IActionResult Edit(Article art)
        {
            _monContext.Articles.Update(art);
            _monContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    }

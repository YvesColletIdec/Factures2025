using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Factures2025.API
{
    //http://localhost:8080/api/ArticleAPI/getARticleById...
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleAPIController : ControllerBase
    {
        private SqliteContext _context;

        public ArticleAPIController(SqliteContext context)
        {
            _context = context;
        }

        [HttpGet("getArticleById")]
        public IActionResult GetArticleById(int id)
        {
            Article art = _context.Articles.Include(a => a.Categorie).FirstOrDefault(a => a.NumArticle == id);
            if (art == null)
            {
                return NotFound($"l'article n° {id} n'existe pas");
            } else
            {
                return Ok(
                    new
                    {
                        Num = art.NumArticle,
                        LeNomDeLArticle = art.Nom,
                        Categorie = art.Categorie.Nom,
                        Prix = art.Prix
                    }
                    );
            }
        }
     }
}

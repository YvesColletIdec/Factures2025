using Entities;
using Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.Data;
using System.Security.Claims;

namespace Factures2025.Controllers
{
    public class LoginController : Controller
    {
        private readonly SqliteContext _context;

        public LoginController(SqliteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            //#if DEBUG
            //            //authentification automatique
            //            Vendeur v = new Vendeur() { Login = "toto", MotDePasse = "1234"};
            //            return Login(v);
            //#else
            //            return View();
            //#endif

            return View();
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();

            return Redirect("~/Login/Login");
        }


        [HttpPost]
        public IActionResult Login(Vendeur v)
        {
            
            Vendeur vendeur = _context.Vendeurs.FirstOrDefault(
                u => u.Login == v.Login
                );
            if (vendeur != null && Security.Verify(v.MotDePasse, vendeur.MotDePasse)) 
            {
                var userClaims = new[] {
                        //new Claim("Login", v.Login),
                        //new Claim("Role", claimRole) ,
                        new Claim(ClaimTypes.Name, vendeur.Nom),//pour authorize
                        new Claim(ClaimTypes.Role, vendeur.Role) ,//pour authorize
                        //new Claim("Id", Convert.ToString(vendeur.NumVendeur))
                    };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(userClaims, "custom");
                //--> il faut laisser custom pour que HttpContext.User.IsAuthenticated soit à True

                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(new[] { claimsIdentity });
                HttpContext.User = userPrincipal;
                HttpContext.SignInAsync(userPrincipal);

                //HttpContext.Session.SetString("id", Convert.ToString(v.NumVendeur));
                //HttpContext.Session.SetString("userName", v.Nom);

                if (User.IsInRole("admin"))
                {
                    TempData["ok"] = "salut admin";
                }
                else
                {
                    TempData["ok"] = "salut user";
                }
                return Redirect("/Maison/Index");

            } else
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }
}

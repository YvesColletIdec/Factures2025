using Entities;
using Helpers;
using Microsoft.EntityFrameworkCore;

namespace TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string mdp = "1234";
            string mdpHAsh = Security.Hash(mdp);
            Console.WriteLine(mdpHAsh);
            //ouvre la connexion à la base de données
            //SqliteContext context = new SqliteContext();

            //insérer un nouvel article
            //insert into article (nom, ....) values ('asdf', .....)
            //Article art = new();
            //art.Nom = "alimentation";
            //art.Prix = 78;
            //context.Articles.Add(art);
            //context.SaveChanges();

            //récupérer un article, le mettre à jour et l'enregistrer
            //récupération de l'article num 4
            //Article art = context.Articles.FirstOrDefault(a => a.NumArticle == 4);
            //art.Prix *= 2;
            //context.SaveChanges();

            //supprimer l'article 23
            //Article art = context.Articles.FirstOrDefault(a => a.NumArticle == 23);
            //if (art != null)
            //{
            //    context.Articles.Remove(art);
            //    context.SaveChanges();
            //}

            //récupérer et afficher le nom de tous les articles
            //select * from article where prix >= 400 --> LINQ
            //List<Article> articles = context.Articles.Where(a => a.Prix >= 400).ToList();
            ////la liste de tous les noms d'articles qui coutent +400
            //List<string> noms = context.Articles.Where(a => a.Prix >= 400)
            //    .Select(a => a.Nom).ToList();
            //foreach (string s in noms)
            //{
            //    Console.WriteLine(s);
            //}
            ////idem en LINQ
            //noms.ForEach(a => Console.WriteLine(a));
            ////on filtre sur les noms qui ont plus de 10 caractères
            //noms = noms.Where(n => n.Length > 10).ToList();

            //foreach (Article a in articles)
            //{
            //    Console.WriteLine($"{a.NumArticle} - {a.Nom} : {a.PrixCHF}");
            //}

            ////récupérer la 1ère facture que l'on trouve et afficher les nom et prénom du client
            ////installer le package nuget entityFrameworkCore
            ////select top 1 * from facture f inner join client c on f.numclient = c.numclient 
            //Facture facture = context.Factures.Include(c => c.NumClientNavigation)
            //    .Include(v => v.NumVendeurNavigation)
            //    .Include(fa => fa.FactureArticles).ThenInclude(a => a.NumArticleNavigation)
            //    .FirstOrDefault();
            ////string prenomNom = facture.NumClientNavigation.Prenom + " " + facture.NumClientNavigation.Nom;
            //Console.WriteLine($"{facture.NumFacture} : {facture.NumClientNavigation.PrenomNom}");
        }
    }
}

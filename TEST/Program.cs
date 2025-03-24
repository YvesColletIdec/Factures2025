using Entities;

namespace TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ouvre la connexion à la base de données
            SqliteContext context = new SqliteContext();
            //récupérer et afficher le nom de tous les articles
            //select nom from article
            List<Article> articles = context.Articles.ToList();
            foreach (Article article in articles)
            {
                Console.WriteLine(article.Nom);
            }

        }
    }
}

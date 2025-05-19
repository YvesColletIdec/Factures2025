using System;
using System.Collections.Generic;

namespace Entities;

public partial class Article
{
    public int NumArticle { get; set; }

    public string Nom { get; set; } = null!;

    public decimal Prix { get; set; }

    public int CategorieId { get; set; }

    public bool EstActif { get; set; }

    public virtual Categorie Categorie { get; set; } = null!;

    public virtual ICollection<FactureArticle> FactureArticles { get; set; } = new List<FactureArticle>();
}

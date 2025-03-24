using System;
using System.Collections.Generic;

namespace Entities;

public partial class Article
{
    public int NumArticle { get; set; }

    public string Nom { get; set; } = null!;

    public decimal Prix { get; set; }

    public virtual ICollection<FactureArticle> FactureArticles { get; set; } = new List<FactureArticle>();
}

using System;
using System.Collections.Generic;

namespace Entities;

public partial class Categorie
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}

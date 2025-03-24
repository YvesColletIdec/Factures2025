using System;
using System.Collections.Generic;

namespace Entities;

public partial class FactureArticle
{
    public int NumFactureArticle { get; set; }

    public int NumFacture { get; set; }

    public int NumArticle { get; set; }

    public int Quantite { get; set; }

    public double Prix { get; set; }

    public virtual Article NumArticleNavigation { get; set; } = null!;

    public virtual Facture NumFactureNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Entities;

public partial class Facture
{
    public int NumFacture { get; set; }

    public DateOnly DateFacture { get; set; }

    public int NumClient { get; set; }

    public int NumVendeur { get; set; }

    public virtual ICollection<FactureArticle> FactureArticles { get; set; } = new List<FactureArticle>();

    public virtual Client NumClientNavigation { get; set; } = null!;

    public virtual Vendeur NumVendeurNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Entities;

public partial class Client
{
    public int NumClient { get; set; }

    public string CodePostal { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public DateOnly DateDeNaissance { get; set; }

    public string Adresse { get; set; } = null!;

    public virtual ICollection<Facture> Factures { get; set; } = new List<Facture>();
}

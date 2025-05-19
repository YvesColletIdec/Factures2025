using System;
using System.Collections.Generic;

namespace Entities;

public partial class Vendeur
{
    public int NumVendeur { get; set; }

    public string Login { get; set; } = null!;

    public string MotDePasse { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Evenement> Evenements { get; set; } = new List<Evenement>();

    public virtual ICollection<Facture> Factures { get; set; } = new List<Facture>();
}

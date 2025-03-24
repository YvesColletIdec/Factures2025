using System;
using System.Collections.Generic;

namespace Entities;

public partial class Evenement
{
    public int NumEvenement { get; set; }

    public DateTime DateEvenement { get; set; }

    public string Description { get; set; } = null!;

    public int NumVendeur { get; set; }

    public string? TypeEvenement { get; set; }

    public virtual Vendeur NumVendeurNavigation { get; set; } = null!;
}

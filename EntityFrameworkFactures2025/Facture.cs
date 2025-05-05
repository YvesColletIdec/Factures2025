using System;
using System.Collections.Generic;

namespace Entities;

public partial class Facture
{
    public int NombreArticles { 
        get {
            return this.FactureArticles.Sum(fa => fa.Quantite);
        }
    }
}

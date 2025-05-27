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

    public double MontantTotalCHF
    {
        get
        {
            double result = 0;
            foreach (var fa in this.FactureArticles)
            {
                result += fa.Quantite * fa.Prix;
            }
            return result;
        }
    }
}

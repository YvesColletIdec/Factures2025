using System;
using System.Collections.Generic;

namespace Entities;

public partial class Article
{
    public string PrixCHF
    {
        get { return $"{Prix} CHF"; }
    }
}

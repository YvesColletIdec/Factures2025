using System;
using System.Collections.Generic;

namespace Entities;

public partial class Client
{
    public string PrenomNom { get { return $"{Prenom} {Nom}"; }}
}

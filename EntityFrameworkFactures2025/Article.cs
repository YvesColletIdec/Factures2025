using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

[ModelMetadataTypeAttribute(typeof(ArticleMetaData))]
public partial class Article
{
    public Article()
    {
        Nom = "";
        Prix = 10;
    }
    public string PrixCHF
    {
        get { return $"{Prix} CHF"; }
    }
}

//classe qui nous permet de mettre des méta-données à nos propriétés
public partial class ArticleMetaData
{
    [Required(ErrorMessage = "Le nom de l'article est obligatoire")]
    [MinLength(3, ErrorMessage = "Attention le nom de l'article requiert 3 caractères")]
    public string Nom { get; set; }

    [Required(ErrorMessage = "Le prix de l'article est obligatoire")]
    [Range(1, 10000, ErrorMessage = "Le prix doit être compris entre 1 et 10'000")]
    public decimal Prix { get; set; }
}

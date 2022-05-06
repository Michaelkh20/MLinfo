using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MLinfo_v1._0.Models;

public class MLMethod
{
    [Key]
    public int ID { get; set; }

    [DisplayName("Name English")]
    public string NameE { get; set; } = null!;

    [DisplayName("Name Russian")]
    public string NameR { get; set; } = null!;

    [ValidateNever]
    public List<Article> Articles { get; set; } = new();

    public string ArticlesToString()
    {
        return (Articles.Count == 0) ? "---" : string.Join(", ", Articles.Select(article => article.Title));
    }
}
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MLinfo_v1._0.Models.DBModels;

public class Keyword
{
    [Key]
    public int ID { get; set; }

    [DisplayName("Keyword English")]
    public string KeywordE { get; set; } = null!;

    [DisplayName("Keyword Russian")]
    public string KeywordR { get; set; } = null!;

    [ValidateNever]
    public List<Article> Articles { get; set; } = new();

    public string ArticlesToString()
    {
        return Articles.Count == 0 ? "---" : string.Join(", ", Articles.Select(article => article.Title));
    }
}
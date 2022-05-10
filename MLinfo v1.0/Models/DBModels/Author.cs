using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MLinfo_v1._0.Models.DBModels;

public class Author
{
    [Key]
    public int ID { get; set; }

    [DisplayName("Name English")]
    public string NameE { get; set; } = null!;

    [DisplayName("Name Russian")]
    public string NameR { get; set; } = null!;

    [ValidateNever]
    public List<Article> Articles { get; set; } = new();

    [ValidateNever]
    public List<Organization> Organizations { get; set; } = new();

    public void Update(Author author)
    {
        ID = author.ID;
        NameE = author.NameE;
        NameR = author.NameR;
    }


    public string ArticlesToString()
    {
        return Articles.Count == 0 ? "---" : string.Join(", ", Articles.Select(article => article.Title));
    }

    public string OrganizationsToString()
    {
        return Organizations.Count == 0 ? "---" : string.Join(", ", Organizations.Select(article => article.NameE));
    }
}
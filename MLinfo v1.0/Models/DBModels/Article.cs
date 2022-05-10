using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MLinfo_v1._0.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MLinfo_v1._0.Models.DBModels;

public class Article
{
    [Key]
    public int ID { get; set; }

    [ValidateNever]
    public Language Language { get; set; } = null!;

    public string Title { get; set; } = null!;
    public int Year { get; set; }
    public string Source { get; set; } = null!;
    public int Volume { get; set; }
    public int Issue { get; set; }
    public string Pages { get; set; } = null!;
    public string? DOI { get; set; }
    public string? Comment { get; set; }

    [ValidateNever]
    public Article? SecondaryArticle { get; set; }

    public string? PDFfile { get; set; }

    [ValidateNever]
    public List<Author> Authors { get; set; } = new();

    [ValidateNever]
    public List<MLMethod>? Methods { get; set; } = new();

    [ValidateNever]
    public List<Keyword>? Keywords { get; set; } = new();

    public void Update(Article article)
    {
        ID = article.ID;
        Title = article.Title;
        Year = article.Year;
        Source = article.Source;
        Volume = article.Volume;
        Issue = article.Issue;
        Pages = article.Pages;
        DOI = article.DOI;
        Comment = article.Comment;
        PDFfile = article.PDFfile;
    }

    public string AuthorsToString()
    {
        return Authors.Count == 0 ? "---" : string.Join(", ", Authors.Select(x => x.NameE));
    }

    public string MethodsToString()
    {
        return Methods!.Count == 0 ? "---" : string.Join(", ", Methods.Select(x => x.NameE));
    }

    public string KeywordsToString()
    {
        return Keywords!.Count == 0 ? "---" : string.Join(", ", Keywords.Select(x => x.KeywordE));
    }

    public string SecondaryArticleToString()
    {
        return SecondaryArticle == null ? "---" : SecondaryArticle.Title;
    }
}
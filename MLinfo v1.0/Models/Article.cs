using System.ComponentModel.DataAnnotations;

namespace MLinfo_v1._0.Models;

public class Article
{
    [Key]
    public int ID { get; set; }
    public Language Language { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int Year { get; set; }
    public string Source { get; set; } = null!;
    public int Volume { get; set; }
    public int Issue { get; set; }
    public string Pages { get; set; } = null!;
    public string? DOI { get; set; }  
    public string? Comment { get; set; }  
    public Article? SecondaryArticle { get; set; }
    public string? PDFfile { get; set; }
    public List<Author> Authors { get; set; } = new();
    public List<MLMethod>? Methods { get; set; } = new();
    public List<Keyword>? Keywords { get; set; } = new();
}
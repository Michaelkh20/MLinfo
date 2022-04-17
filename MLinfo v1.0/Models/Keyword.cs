using System.ComponentModel.DataAnnotations;

namespace MLinfo_v1._0.Models;

public class Keyword
{
    [Key]
    public int ID { get; set; }
    public string KeywordE { get; set; } = null!;
    public string KeywordR { get; set; } = null!;
    public List<Article> Articles { get; set; } = new();
}
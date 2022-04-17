using System.ComponentModel.DataAnnotations;

namespace MLinfo_v1._0.Models;

public class Organization
{
    [Key]
    public int ID { get; set; }
    public string NameE { get; set; } = null!;
    public string NameR { get; set; } = null!;
    public Country Country { get; set; } = null!;
    public List<Author> Authors { get; set; } = new();
}
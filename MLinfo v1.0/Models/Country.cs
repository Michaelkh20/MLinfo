using System.ComponentModel.DataAnnotations;

namespace MLinfo_v1._0.Models;

public class Country
{
    [Key]
    public int ID { get; set; }
    public string NameE { get; set; } = null!;
    public string NameR { get; set; } = null!;
    public List<Organization> Organizations { get; set; } = new();
}
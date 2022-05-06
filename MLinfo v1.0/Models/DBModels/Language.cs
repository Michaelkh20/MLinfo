using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MLinfo_v1._0.Models;

public class Language
{
    [Key]
    public int ID { get; set; }

    [DisplayName("Name English")]
    public string NameE { get; set; } = null!;

    [DisplayName("Name Russian")]
    public string NameR { get; set; } = null!;
}
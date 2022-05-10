using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MLinfo_v1._0.Models.DBModels;

public class Country
{
    [Key]
    public int ID { get; set; }

    [DisplayName("Name English")]
    public string NameE { get; set; } = null!;

    [DisplayName("Name Russian")]
    public string NameR { get; set; } = null!;

    [ValidateNever]
    public List<Organization> Organizations { get; set; } = new();

    public string OrganizationsToString()
    {
        return Organizations.Count == 0 ? "---" : string.Join(", ", Organizations.Select(x => x.NameE));
    }
}
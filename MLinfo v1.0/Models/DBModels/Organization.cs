using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MLinfo_v1._0.Models;

public class Organization
{
    [Key]
    public int ID { get; set; }

    [DisplayName("Name English")]
    public string NameE { get; set; } = null!;

    [DisplayName("Name Russian")]
    public string NameR { get; set; } = null!;

    [ValidateNever]
    public Country Country { get; set; } = null!;

    [ValidateNever]
    public List<Author> Authors { get; set; } = new();

    public void Update(Organization organization)
    {
        ID = organization.ID;
        NameE = organization.NameE;
        NameR = organization.NameR;
    }

    public string AuthorsToString()
    {
        return (Authors.Count == 0) ? "---" : string.Join(", ", Authors.Select(x => x.NameE));
    }
}
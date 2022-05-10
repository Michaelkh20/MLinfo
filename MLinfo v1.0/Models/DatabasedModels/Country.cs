using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLinfo_v1._0.Models.DatabasedModels
{
    [Table("CountriesInfo")]
    public partial class Country
    {
        [Column("CountryId")]
        public int ID { get; set; }

        [Column("CountryE")]
        [DisplayName("Name English")]
        public string NameE { get; set; } = null!;

        [Column("CountryR")]
        [DisplayName("Name Russian")]
        public string NameR { get; set; } = null!;

        [ValidateNever]
        public virtual List<Organization> Organizations { get; set; } = new();

        public string OrganizationsToString()
        {
            return (Organizations.Count == 0) ? "---" : string.Join(", ", Organizations.Select(x => x.NameE));
        }
    }
}

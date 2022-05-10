using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLinfo_v1._0.Models.DatabasedModels
{
    [Table("OrganizationsInfo")]
    public partial class Organization
    {
        [Column("OrganizationId")]
        public int ID { get; set; }

        [Column("OrganizationE")]
        [DisplayName("Name English")]
        public string? NameE { get; set; }

        [Column("OrganizationR")]
        [DisplayName("Name Russian")]
        public string? NameR { get; set; }

        [DisplayName("Country")]
        public int? CountryId { get; set; }

        [ValidateNever]
        public virtual Country? Country { get; set; }

        [ValidateNever]
        public virtual List<Author> Authors { get; set; } = new();

        public void Update(Organization organization)
        {
            ID = organization.ID;
            NameE = organization.NameE;
            NameR = organization.NameR;
            CountryId = organization.CountryId;
        }

        public string AuthorsToString()
        {
            return (Authors.Count == 0) ? "---" : string.Join(", ", Authors.Select(x => x.NameE));
        }
    }
}

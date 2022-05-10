using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLinfo_v1._0.Models.DatabasedModels
{
    [Table("AuthorsInfo")]
    public partial class Author
    {
        [Column("AuthorId")]
        public int ID { get; set; }

        [Column("AuthorNameE")]
        [DisplayName("Name English")]
        public string? NameE { get; set; }

        [Column("AuthorNameR")]
        [DisplayName("Name Russian")]
        public string? NameR { get; set; }

        [ValidateNever]
        public virtual List<Organization>? Organizations { get; set; } = new();

        [ValidateNever]
        public virtual List<Article>? Articles { get; set; } = new();

        public void Update(Author author)
        {
            ID = author.ID;
            NameE = author.NameE;
            NameR = author.NameR;
        }

        public string ArticlesToString()
        {
            return (Articles.Count == 0) ? "---" : string.Join(", ", Articles.Select(article => article.TitleE));
        }

        public string OrganizationsToString()
        {
            return (Organizations.Count == 0) ? "---" : string.Join(", ", Organizations.Select(article => article.NameE));
        }
    }
}

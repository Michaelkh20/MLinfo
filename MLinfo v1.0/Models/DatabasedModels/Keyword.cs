using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLinfo_v1._0.Models.DatabasedModels
{
    [Table("KeywordsInfo")]
    public partial class Keyword
    {
        [Column("KeywordId")]
        public int ID { get; set; }

        [DisplayName("Keyword English")]
        public string? KeywordE { get; set; }

        [DisplayName("Keyword Russian")]
        public string? KeywordR { get; set; }

        [ValidateNever]
        public virtual List<Article> Articles { get; set; } = new();

        public string ArticlesToString()
        {
            return (Articles.Count == 0) ? "---" : string.Join(", ", Articles.Select(article => article.TitleE));
        }
    }
}

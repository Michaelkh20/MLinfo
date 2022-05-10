using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLinfo_v1._0.Models.DatabasedModels
{
    [Table("MethodMlinfo")]
    public partial class MLMethod
    {
        [Column("MethodId")]
        public int ID { get; set; }

        [Column("MethodE")]
        [DisplayName("Name English")]
        public string? NameE { get; set; }

        [Column("MethodR")]
        [DisplayName("Name Russian")]
        public string? NameR { get; set; }

        [ValidateNever]
        public virtual List<Article> Articles { get; set; } = new();

        public string ArticlesToString()
        {
            return (Articles.Count == 0) ? "---" : string.Join(", ", Articles.Select(article => article.TitleE));
        }
    }
}

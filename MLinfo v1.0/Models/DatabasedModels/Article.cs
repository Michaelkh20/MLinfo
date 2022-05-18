using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLinfo_v1._0.Models.DatabasedModels
{
    [Table("ReferencesInfo")]
    public partial class Article
    {
        [Column("ReferenceId")]
        public int ID { get; set; }

        [DisplayName("Authors English")]
        public string? AuthorsE { get; set; }

        [DisplayName("Authors in Russian")]
        public string? AuthorsR { get; set; }

        [Column("ArticleE")]
        [DisplayName("English title")]
        public string? TitleE { get; set; }

        [Column("ArticleR")]
        [DisplayName("Russian title")]
        public string? TitleR { get; set; }

        [DisplayName("English source")]
        public string? SourceE { get; set; }

        [DisplayName("Russian source")]
        public string? SourceR { get; set; }

        public int? Year { get; set; }

        [DisplayName("English volume")]
        public string? VolumeE { get; set; }

        [DisplayName("Russian volume")]
        public string? VolumeR { get; set; }

        [Column("Number")]
        public string? Issue { get; set; }

        [DisplayName("English pages")]
        public string? PagesE { get; set; }

        [DisplayName("Russian pages")]
        public string? PagesR { get; set; }

        [DisplayName("English DOI")]
        public string? Doie { get; set; }

        [DisplayName("Russian DOI")]
        public string? Doir { get; set; }

        [DisplayName("English comment")]
        public string? CommentE { get; set; }

        [DisplayName("Russian comment")]
        public string? CommentR { get; set; }

        [DisplayName("PDF file")]
        public string? PdfFile { get; set; }

        [ValidateNever]
        public virtual List<Author> Authors { get; set; } = new();
        [ValidateNever]
        public virtual List<Keyword> Keywords { get; set; } = new();
        [ValidateNever]
        public virtual List<MLMethod> Methods { get; set; } = new();

        public void Update(Article article)
        {
            ID = article.ID;
            AuthorsE = article.AuthorsE;
            AuthorsR = article.AuthorsR;
            TitleE = article.TitleE;
            TitleR = article.TitleR;
            SourceE = article.SourceE;
            SourceR = article.SourceR;
            Year = article.Year;
            VolumeE = article.VolumeE;
            VolumeR = article.VolumeR;
            Issue = article.Issue;
            PagesE = article.PagesE;
            PagesR = article.PagesR;
            Doie = article.Doie;
            Doir = article.Doir;
            CommentE = article.CommentE;
            CommentR = article.CommentR;
            PdfFile = article.PdfFile;
        }

        public string AuthorsToString()
        {
            return (Authors.Count == 0) ? "---" : string.Join(", ", Authors.Select(x => x.NameE));
        }

        public string MethodsToString()
        {
            return (Methods!.Count == 0) ? "---" : string.Join(", ", Methods.Select(x => x.NameE));
        }

        public string KeywordsToString()
        {
            return (Keywords!.Count == 0) ? "---" : string.Join(", ", Keywords.Select(x => x.KeywordE));
        }

    }
}

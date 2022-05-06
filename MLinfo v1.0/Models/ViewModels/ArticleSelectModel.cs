using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace MLinfo_v1._0.Models.ViewModels
{
    public class ArticleSelectModel
    {
        public ArticleSelectModel()
        {
            ArticleDB = new Article();
        }

        public ArticleSelectModel(Article article)
        {
            ArticleDB = article;
            SelectedLangId = article.Language.ID;
            if (article.SecondaryArticle != null)
            {
                SelectedScArticleId = article.SecondaryArticle.ID;
            }

            SelectedAuthorIds = article.Authors.Select(author => author.ID).ToList();
            SelectedMethodIds = article.Methods!.Select(method => method.ID).ToList();
            SelectedKeywordIds = article.Keywords!.Select(keyword => keyword.ID).ToList();
        }

        public Article ArticleDB { get; set; }

        [DisplayName("Language")]
        public int SelectedLangId { get; set; }
        public List<SelectListItem> Languages { get; set; } = new();

        [DisplayName("Authors")]
        public List<int> SelectedAuthorIds { get; set; } = new();
        public List<SelectListItem> Authors { get; set; } = new();

        [DisplayName("Secondary Article")]
        public int? SelectedScArticleId { get; set; }
        public List<SelectListItem> SecondaryArticles { get; set; } = new();

        [DisplayName("Methods")]
        public List<int>? SelectedMethodIds { get; set; } = new();
        public List<SelectListItem> Methods { get; set; } = new();

        [DisplayName("Keywords")]
        public List<int>? SelectedKeywordIds { get; set; } = new();
        public List<SelectListItem> Keywords { get; set; } = new();
    }
}

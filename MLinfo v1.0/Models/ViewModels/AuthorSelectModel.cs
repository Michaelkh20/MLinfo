 using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace MLinfo_v1._0.Models.ViewModels
{
    public class AuthorSelectModel
    {
        public AuthorSelectModel()
        {
            AuthorDB = new Author();
        }

        public AuthorSelectModel(Author author)
        {
            AuthorDB = author;
            SelectedOrgIds = author.Organizations.Select(org=> org.ID).ToList();
        }

        public Author AuthorDB { get; set; }

        [DisplayName("Organizations")]
        public List<int> SelectedOrgIds { get; set; } = new();
        public List<SelectListItem>? Organizations { get; set; } = new();
    }
}

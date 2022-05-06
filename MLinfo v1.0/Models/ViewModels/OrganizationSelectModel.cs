using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace MLinfo_v1._0.Models.ViewModels
{
    public class OrganizationSelectModel
    {
        public OrganizationSelectModel()
        {
            OrganizationDB = new Organization();
        }

        public OrganizationSelectModel(Organization organization)
        {
            OrganizationDB = organization;
            SelectedCountryId = organization.Country.ID;
        }

        public Organization OrganizationDB { get; set; }

        [DisplayName("Country")]
        public int SelectedCountryId { get; set; } = new();
        public List<SelectListItem>? Countries { get; set; } = new();
    }
}


using Microsoft.AspNetCore.Mvc.Rendering;
using MLinfo_v1._0.Models.DatabasedModels;
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
        }

        public Organization OrganizationDB { get; set; }

        public List<SelectListItem>? Countries { get; set; } = new();
    }
}


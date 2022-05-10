#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MLinfo_v1._0.Data;
using MLinfo_v1._0.Models.DatabasedModels;
//using MLinfo_v1._0.Models.DBModels;
using MLinfo_v1._0.Models.ViewModels;

namespace MLinfo_v1._0.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public OrganizationsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Organizations
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrganizationsInfos.Include(org => org.Country).Include(org => org.Authors).ToListAsync());
        }

        // GET: Organizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await GetOrganizationFromDB(id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // GET: Organizations/Create
        public IActionResult Create()
        {
            var orgSM = new OrganizationSelectModel();
            PopulateOrganizationSM(orgSM);
            return View(orgSM);
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("ID,NameE,NameR")]*/ OrganizationSelectModel orgSM)
        {
            if (ModelState.IsValid)
            {
                Organization org = orgSM.OrganizationDB;

                FillOrganizationCollectionsDB(org, orgSM);

                _context.Add(orgSM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateOrganizationSM(orgSM);
            return View(orgSM);
        }

        // GET: Organizations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await GetOrganizationFromDB(id);

            if (organization == null)
            {
                return NotFound();
            }
            
            var orgSM = new OrganizationSelectModel(organization);
            PopulateOrganizationSM(orgSM);
            return View(orgSM);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, /*[Bind("ID,NameE,NameR")]*/ OrganizationSelectModel orgSM)
        {
            if (id != orgSM.OrganizationDB.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var org = await GetOrganizationFromDB(id);
                    org.Update(orgSM.OrganizationDB);

                    FillOrganizationCollectionsDB(org, orgSM);

                    _context.OrganizationsInfos.Update(org);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationExists(orgSM.OrganizationDB.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            PopulateOrganizationSM(orgSM);
            return View(orgSM);
        }

        // GET: Organizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await GetOrganizationFromDB(id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organization = await GetOrganizationFromDB(id);
            _context.OrganizationsInfos.Remove(organization);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationExists(int id)
        {
            return _context.OrganizationsInfos.Any(e => e.ID == id);
        }

        private void PopulateOrganizationSM(OrganizationSelectModel orgSM)
        {
            orgSM.Countries = _context.CountriesInfos.Select(country => new SelectListItem() { Text = country.NameE, Value = country.ID.ToString() }).ToList();
        }

        private async Task<Organization> GetOrganizationFromDB(int? id)
        {
            return await _context.OrganizationsInfos.Include(org => org.Country).Include(org => org.Authors).
                            FirstOrDefaultAsync(org => org.ID == id);
        }


        private void FillOrganizationCollectionsDB(Organization org, OrganizationSelectModel orgSM)
        {
            org.Country = (orgSM.OrganizationDB.CountryId != -1) ? _context.CountriesInfos.Find(orgSM.OrganizationDB.CountryId) : null;
        }
    }
}

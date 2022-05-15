#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MLinfo_v1._0.Data;
using MLinfo_v1._0.Models.DatabasedModels;
//using MLinfo_v1._0.Models.DBModels;
using MLinfo_v1._0.Models.ViewModels;

namespace MLinfo_v1._0.Controllers
{
    [Authorize(Roles ="moderator, administrator")]
    public class AuthorsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AuthorsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            return View(await _context.AuthorsInfos.Include(author => author.Articles).Include(author => author.Organizations).ToListAsync());
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await GetAuthorFromDB(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            var authorSM = new AuthorSelectModel();
            PopulateAuthorSM(authorSM);
            return View(authorSM);
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("ID,NameE,NameR")]*/ AuthorSelectModel authorSM)
        {
            if (ModelState.IsValid)
            {
                Author author = authorSM.AuthorDB;

                FillAuthorCollectionsDB(author, authorSM);

                _context.AuthorsInfos.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateAuthorSM(authorSM);
            return View(authorSM);
        }


        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await GetAuthorFromDB(id);

            if (author == null)
            {
                return NotFound();
            }

            var authorSM = new AuthorSelectModel(author);
            PopulateAuthorSM(authorSM);
            return View(authorSM);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, /*[Bind("ID,NameE,NameR")]*/ AuthorSelectModel authorSM)
        {
            if (id != authorSM.AuthorDB.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var author = await GetAuthorFromDB(id);
                    author.Update(authorSM.AuthorDB);

                    FillAuthorCollectionsDB(author, authorSM);

                    _context.AuthorsInfos.Update(author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(authorSM.AuthorDB.ID))
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

            PopulateAuthorSM(authorSM);
            return View(authorSM);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await GetAuthorFromDB(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await GetAuthorFromDB(id);
            _context.AuthorsInfos.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            return _context.AuthorsInfos.Any(e => e.ID == id);
        }
        private void PopulateAuthorSM(AuthorSelectModel authorSM)
        {
            authorSM.Organizations = _context.OrganizationsInfos.Select(org => new SelectListItem() { Text = org.NameE, Value = org.ID.ToString() }).ToList();
        }

        private async Task<Author> GetAuthorFromDB(int? id)
        {
            return await _context.AuthorsInfos.Include(author => author.Articles).Include(author => author.Organizations).
                            FirstOrDefaultAsync(author => author.ID == id);
        }


        private void FillAuthorCollectionsDB(Author author, AuthorSelectModel authorSM)
        {
            author.Organizations = (from org in _context.OrganizationsInfos.ToList()
                                    join orgId in authorSM.SelectedOrgIds on org.ID equals orgId
                                    select org).ToList();
        }
    }
}

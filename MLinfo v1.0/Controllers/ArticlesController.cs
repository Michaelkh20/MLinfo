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
//using MLinfo_v1._0.Models;
using MLinfo_v1._0.Models.DatabasedModels;
using MLinfo_v1._0.Models.ViewModels;

namespace MLinfo_v1._0.Controllers
{
    [Authorize(Roles = "moderator, administrator")]
    public class ArticlesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ArticlesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReferencesInfos.
                            Include(article => article.Authors).Include(article => article.Methods).Include(article => article.Keywords).ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await GetArticleFromDB(id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            var articleSM = new ArticleSelectModel();
            PopulatearticleSM(articleSM);
            return View(articleSM);
        }

        // POST: Articles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("ID,Title,Year,Source,Volume,Issue,Pages,DOI,Comment,PDFfile")]*/ ArticleSelectModel articleSM)
        {
            if (ModelState.IsValid)
            {
                Article article = articleSM.ArticleDB;

                FillArticleCollectionsDB(article, articleSM);

                _context.ReferencesInfos.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulatearticleSM(articleSM);
            return View(articleSM);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article article = await GetArticleFromDB(id);

            if (article == null)
            {
                return NotFound();
            }

            var articleSM = new ArticleSelectModel(article);
            PopulatearticleSM(articleSM);
            return View(articleSM);
        }


        // POST: Articles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, /*[Bind("ID,Title,Year,Source,Volume,Issue,Pages,DOI,Comment,PDFfile")]*/ ArticleSelectModel articleSM)
        {
            if (id != articleSM.ArticleDB.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Article article = await GetArticleFromDB(id);
                    article.Update(articleSM.ArticleDB);

                    FillArticleCollectionsDB(article, articleSM);

                    _context.ReferencesInfos.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(articleSM.ArticleDB.ID))
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

            PopulatearticleSM(articleSM);
            return View(articleSM);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await GetArticleFromDB(id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await GetArticleFromDB(id);
            _context.ReferencesInfos.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.ReferencesInfos.Any(e => e.ID == id);
        }

        private void PopulatearticleSM(ArticleSelectModel articleSM)
        {
            articleSM.Authors = _context.AuthorsInfos.Select(author => new SelectListItem() { Text = author.NameE, Value = author.ID.ToString() }).ToList();
            articleSM.Methods = _context.MethodMlinfos.Select(method => new SelectListItem() { Text = method.NameE, Value = method.ID.ToString() }).ToList();
            articleSM.Keywords = _context.KeywordsInfos.Select(keyword => new SelectListItem() { Text = keyword.KeywordE, Value = keyword.ID.ToString() }).ToList();
        }

        private void FillArticleCollectionsDB(Article article, ArticleSelectModel articleSM)
        {
            article.Authors = (from author in _context.AuthorsInfos.ToList()
                               join authorId in articleSM.SelectedAuthorIds on author.ID equals authorId
                               select author).ToList();
            article.Methods = (from method in _context.MethodMlinfos.ToList()
                               join methodId in articleSM.SelectedMethodIds on method.ID equals methodId
                               select method).ToList();
            article.Keywords = (from keyword in _context.KeywordsInfos.ToList()
                                join keywordId in articleSM.SelectedKeywordIds on keyword.ID equals keywordId
                                select keyword).ToList();
        }

        private async Task<Article> GetArticleFromDB(int? id)
        {
            return await _context.ReferencesInfos.
                            Include(article => article.Authors).Include(article => article.Methods).Include(article => article.Keywords).
                            FirstOrDefaultAsync(article => article.ID == id);
        }

    }
}

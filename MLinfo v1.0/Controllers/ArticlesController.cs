#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MLinfo_v1._0.Data;
using MLinfo_v1._0.Models;
using MLinfo_v1._0.Models.ViewModels;

namespace MLinfo_v1._0.Controllers
{
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
            return View(await _context.Articles.Include(article => article.Language).Include(article => article.SecondaryArticle).
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

                _context.Articles.Add(article);
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

                    _context.Articles.Update(article);
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
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ID == id);
        }

        private void PopulatearticleSM(ArticleSelectModel articleSM)
        {
            articleSM.Languages = _context.Languages.Select(language => new SelectListItem() { Text = language.NameE, Value = language.ID.ToString() }).ToList();
            articleSM.SecondaryArticles = _context.Articles.Select(article => new SelectListItem() { Text = article.Title, Value = article.ID.ToString() }).ToList();
            articleSM.Authors = _context.Authors.Select(author => new SelectListItem() { Text = author.NameE, Value = author.ID.ToString() }).ToList();
            articleSM.Methods = _context.MlMethods.Select(method => new SelectListItem() { Text = method.NameE, Value = method.ID.ToString() }).ToList();
            articleSM.Keywords = _context.Keywords.Select(keyword => new SelectListItem() { Text = keyword.KeywordE, Value = keyword.ID.ToString() }).ToList();
        }

        private void FillArticleCollectionsDB(Article article, ArticleSelectModel articleSM)
        {
            article.Language = _context.Languages.Find(articleSM.SelectedLangId);
            article.Authors = (from author in _context.Authors.ToList()
                               join authorId in articleSM.SelectedAuthorIds on author.ID equals authorId
                               select author).ToList();
            article.Methods = (from method in _context.MlMethods.ToList()
                               join methodId in articleSM.SelectedMethodIds on method.ID equals methodId
                               select method).ToList();
            article.Keywords = (from keyword in _context.Keywords.ToList()
                                join keywordId in articleSM.SelectedKeywordIds on keyword.ID equals keywordId
                                select keyword).ToList();
            article.SecondaryArticle = (articleSM.SelectedScArticleId != -1) ? _context.Articles.Find(articleSM.SelectedScArticleId) : null;
        }

        private async Task<Article> GetArticleFromDB(int? id)
        {
            return await _context.Articles.Include(article => article.Language).Include(article => article.SecondaryArticle).
                            Include(article => article.Authors).Include(article => article.Methods).Include(article => article.Keywords).
                            FirstOrDefaultAsync(article => article.ID == id);
        }

    }
}

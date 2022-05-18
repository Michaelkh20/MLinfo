using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLinfo_v1._0.Data;
using MLinfo_v1._0.Models;
using MLinfo_v1._0.Models.DatabasedModels;

namespace MLinfo_v1._0.Controllers
{

    public class HomeController : Controller
    {
        ApplicationDBContext _context;

        public HomeController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(string SearchString, string SearchBy)
        {
            if (string.IsNullOrEmpty(SearchString))
            {
                var emptyQuery = _context.ReferencesInfos.Include(article => article.Keywords).Include(article => article.Methods);
                return View(emptyQuery);
            }


            switch (SearchBy)
            {
                default:
                case "Title":
                    var titleQuery = _context.ReferencesInfos.Include(article => article.Keywords).Include(article => article.Methods)
                        .Where(article => ((article.TitleE != null) && article.TitleE.Contains(SearchString))
                       || ((article.TitleR != null) && article.TitleR.Contains(SearchString)));

                    return View(titleQuery);
                case "Author":
                    var authorQuery = _context.AuthorsInfos.Include(author => author.Articles).ThenInclude(article => article.Keywords)
                        .Include(author => author.Articles).ThenInclude(article => article.Methods)
                        .Where(author => ((author.NameE != null) && author.NameE.Contains(SearchString))
                       || ((author.NameR != null) && author.NameR.Contains(SearchString))).SelectMany(author => author.Articles);

                    return View(authorQuery);
                case "Keyword":
                    var keywordQuery = _context.KeywordsInfos.Include(keyword => keyword.Articles).ThenInclude(article => article.Keywords)
                        .Include(keyword => keyword.Articles).ThenInclude(article => article.Methods)
                        .Where(keyword => ((keyword.KeywordE != null) && keyword.KeywordE.Contains(SearchString))
                   || ((keyword.KeywordR != null) && keyword.KeywordR.Contains(SearchString))).SelectMany(keyword => keyword.Articles);

                    return View(keywordQuery);
                case "MLMethod":
                    var methodQuery = _context.MethodMlinfos.Include(method => method.Articles).ThenInclude(article => article.Keywords)
                        .Include(method => method.Articles).ThenInclude(article => article.Methods)
                        .Where(method => ((method.NameE != null) && method.NameE.Contains(SearchString))
                   || ((method.NameR != null) && method.NameR.Contains(SearchString))).SelectMany(author => author.Articles);

                    return View(methodQuery);
                case "DOI":
                    var doiQuery = _context.ReferencesInfos.Include(article => article.Keywords).Include(article => article.Methods)
                        .Where(article => ((article.Doie != null) && article.Doie.Contains(SearchString))
                   || ((article.Doir != null) && article.Doir.Contains(SearchString)));

                    return View(doiQuery);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

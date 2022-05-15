using Microsoft.AspNetCore.Mvc;

namespace MLinfo_v1._0.Controllers
{
    public class UserHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

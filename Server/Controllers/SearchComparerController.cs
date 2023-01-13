using Microsoft.AspNetCore.Mvc;

namespace SearchComparer.Server.Controllers
{
    public class SearchComparerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace ProniaProject.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: DashboardController
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

    }
}

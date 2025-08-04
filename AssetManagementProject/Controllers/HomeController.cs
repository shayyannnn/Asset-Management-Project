using Microsoft.AspNetCore.Mvc;

namespace AssetManagementProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // If the request is an AJAX call (from sidebar), return partial view (no layout)
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(); // Will render only the view content (no _Layout)
            }

            return View(); // Will render with _Layout.cshtml
        }
    }
}

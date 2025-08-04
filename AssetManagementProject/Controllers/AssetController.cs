using Microsoft.AspNetCore.Mvc;

namespace AssetManagementProject.Controllers
{
    public class AssetController : Controller
    {
        public IActionResult Assignment()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("assignment");
            }
            return View("assignment");
        }

        public IActionResult Registration()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("registration");
            }
            return View("registration");
        }

        public IActionResult Tagging()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("tagging");
            }
            return View("tagging");
        }
    }
}

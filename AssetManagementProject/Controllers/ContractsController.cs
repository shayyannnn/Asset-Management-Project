// File: Controllers/ContractsController.cs
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementProject.Controllers
{
    public class ContractsController : Controller
    {
        public IActionResult Index()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("Warranty"); // Return partial for AJAX
            }
            return View("Warranty"); // Full view for normal load
        }
    }
}

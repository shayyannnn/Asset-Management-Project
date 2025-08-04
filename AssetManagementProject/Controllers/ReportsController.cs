using Microsoft.AspNetCore.Mvc;

public class ReportsController : Controller
{
    public IActionResult Index()
    {
        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            return PartialView("reports"); // For AJAX: no layout

        return View("reports"); // Full view with layout
    }
}

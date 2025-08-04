using Microsoft.AspNetCore.Mvc;

namespace AssetManagementProject.Controllers
{
    public class SecurityAuditController : Controller
    {
        public IActionResult AuditTrial()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("AuditTrial");

            return View("AuditTrial");
        }

        public IActionResult LogAlerts()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("LogAlerts");

            return View("LogAlerts");
        }

        public IActionResult VulnerabilityTracking()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("VulnerabilityTracking");

            return View("VulnerabilityTracking");
        }
    }
}

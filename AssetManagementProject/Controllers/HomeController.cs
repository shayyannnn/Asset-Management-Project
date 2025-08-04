using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using AssetManagementProject.Models; 

namespace AssetManagementProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AssetManagementDB _context;

        public HomeController(AssetManagementDB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Total assets
            var totalAssets = await _context.Assets.CountAsync();

            // Assigned assets: adjust logic depending on your model.
            // Example A: Asset has AssignedToId non-null
            var assignedAssets = await _context.Assets
                .Where(a => a.Status == "Issued")
                .CountAsync();

            // Example B (if you use a separate assignment table):
            //var assignedAssets = await _context.Issuances
            //   .Where(a => a.IsActive) // however you mark current assignment
            //    .Select(a => a.AssetId)
            //  .Distinct()
            //  .CountAsync();

            // Under maintenance: example if you have a maintenance table
            //var underMaintenance = await _context.Maintenances
            //   .Where(m => m.Status == "InProgress")
            //   .Select(m => m.AssetId)
             //  .Distinct()
             //  .CountAsync();

            var vm = new DashboardViewModel
            {
                TotalAssets = totalAssets,
                AssignedAssets = assignedAssets,
               // UnderMaintenance = underMaintenance
            };

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_DashboardCards", vm);
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateReport()
        {
            // reuse same inline logic; could factor to a private helper if desired
            var totalAssets = await _context.Assets.CountAsync();
            var assignedAssets = await _context.Assets
                .Where(a => a.Status == "Issued")
                .CountAsync();
            //var underMaintenance = await _context.Maintenances
            //    .Where(m => m.EndDate == null || m.EndDate > DateTime.UtcNow)
            //    .Select(m => m.AssetId)
            //    .Distinct()
            //    .CountAsync();

            var vm = new DashboardViewModel
            {
                TotalAssets = totalAssets,
                AssignedAssets = assignedAssets,
             //   UnderMaintenance = underMaintenance
            };

            return Json(new { success = true, data = vm });
        }
    }
}

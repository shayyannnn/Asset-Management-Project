using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var totalAssets = await _context.Assets.CountAsync();
            var assignedAssets = await _context.Assets.CountAsync(a => a.Status == "Issued");
            var underMaintenance = await _context.Assets.CountAsync(a => a.Status == "UnderMaintenance");

            var assetsByCategory = await _context.Assets
            .GroupBy(a => a.AssetType)
             .Select(g => new AssetCategoryData
              {
              Category = g.Key,
              Count = g.Count() 
              })
             .ToListAsync();

            var model = new DashboardViewModel
            {
                TotalAssets = totalAssets,
                AssignedAssets = assignedAssets,
                UnderMaintenance = underMaintenance,
                AssetsByCategory = assetsByCategory
            };

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateReport()
        {
            var totalAssets = await _context.Assets.CountAsync();
            var assignedAssets = await _context.Assets.CountAsync(a => a.Status == "Issued");
           var underMaintenance = await _context.Assets.CountAsync(a => a.Status == "UnderMaintenance");

            var model = new DashboardViewModel
            {
                TotalAssets = totalAssets,
                AssignedAssets = assignedAssets,
                UnderMaintenance = underMaintenance
            };

            return Json(new { success = true, data = model });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssetManagementProject.Models;

namespace AssetManagementProject.Controllers
{
    public class AssetController : Controller
    {
        private readonly AssetManagementDB _context;

        public AssetController(AssetManagementDB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Registration()
        {
            var assets = await _context.Assets
                .Include(a => a.Vendor)
                .OrderByDescending(a => a.AssetId)
                .ToListAsync();

            var vendors = await _context.Vendors.OrderBy(v => v.Name).ToListAsync();
            ViewBag.Vendors = vendors;

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("registration", assets);
            }
            return View("registration", assets);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsset([FromForm] AssetInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Invalid form data." });
            }

            var asset = new Asset
            {
                AssetName = input.AssetName,
                AssetType = input.AssetType,
                Count = input.Count,
                Status = input.Status,
                WarrantyEnd = input.WarrantyEnd,
                StoreItemId = input.StoreItemId,
                StoreItemCode = input.StoreItemCode,
                VendorId = input.VendorId
            };

            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Asset registered successfully!" });
        }

        public IActionResult Assignment()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("assignment");
            }
            return View("assignment");
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

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

            var assetTypes = await _context.AssetTypes.OrderBy(a => a.AssetTypeDp).ToListAsync();
            ViewBag.AssetTypes = assetTypes;

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

        public async Task<IActionResult> Assignment()
        {
            var recentAssignments = await _context.Issuances
                .Include(i => i.Asset)
                .OrderByDescending(i => i.DateAssigned)
                .ToListAsync();


            var assets = await _context.Assets
                .Where(a => a.Status == "Active") 
                .ToListAsync();

            ViewBag.Assets = assets;

            // If the request is AJAX, return partial view
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("assignment", recentAssignments);
            }

            // Return full view with recent assignments as model
            return View("assignment", recentAssignments);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignAsset([FromForm] IssuanceInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Invalid form data." });
            }

            var asset = await _context.Assets.FindAsync(input.AssetId);
            if (asset == null)
            {
                return NotFound(new { success = false, message = "Asset not found." });
            }

            // Update asset status to "Issued"
            asset.Status = "Issued";

            var issuance = new Issuance
            {
                EmploymentId = input.EmploymentId,
                AssetId = input.AssetId,
                IssuedTo = input.IssuedTo,
                Designation = input.Designation,
                DepartmentId = input.DepartmentId,
                DateAssigned = input.DateAssigned,
                Building = input.Building,
                Room = input.Room
            };

            _context.Issuances.Add(issuance);

            // Save changes (asset + issuance)
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Asset assigned successfully!" });
        }

        /*public IActionResult Assignment()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("assignment");
            }
            return View("assignment");
        }*/

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

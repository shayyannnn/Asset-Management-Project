using System.ComponentModel.DataAnnotations;

namespace AssetManagementProject.Models
{
    public class AssetInputModel
    {
        [Required]
        public string AssetName { get; set; }
        [Required]
        public string AssetType { get; set; }
        public int Count { get; set; }
        public string Status { get; set; }
        public DateOnly? WarrantyEnd { get; set; }
        public string? StoreItemId { get; set; }
        public string? StoreItemCode { get; set; }
        public int? VendorId { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace AssetManagementProject.Models
{
    public class IssuanceInputModel
    {
        [Required]
        public int? EmploymentId { get; set; }
        [Required]
        public int? AssetId { get; set; }
        [Required]
        [StringLength(100)]
        public string IssuedTo { get; set; }
        [StringLength(100)]
        public string Designation { get; set; }
        [StringLength(50)]
        public string DepartmentId { get; set; }
        public DateOnly? DateAssigned { get; set; }
        [StringLength(100)]
        public string Building { get; set; }
        [StringLength(50)]
        public string Room { get; set; }
    }
}

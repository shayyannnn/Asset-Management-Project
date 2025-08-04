using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class Contract
{
    public int ContractId { get; set; }

    public int? VendorId { get; set; }

    public string? ContractType { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Cost { get; set; }

    public string? RenewalTerms { get; set; }

    public virtual Vendor? Vendor { get; set; }
}

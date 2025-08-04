using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string? Name { get; set; }

    public string? ContactPerson { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}

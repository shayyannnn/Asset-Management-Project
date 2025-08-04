using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class Asset
{
    public int AssetId { get; set; }

    public string? AssetType { get; set; }

    public string? AssetName { get; set; }

    public int? Count { get; set; }

    public DateOnly? WarrantyEnd { get; set; }

    public string? Status { get; set; }

    public string? StoreItemId { get; set; }

    public string? StoreItemCode { get; set; }

    public int? VendorId { get; set; }

    public int? IssuanceId { get; set; }

    public virtual ICollection<AssetSpec> AssetSpecs { get; set; } = new List<AssetSpec>();

    public virtual AssetType? AssetTypeNavigation { get; set; }

    public virtual ICollection<AssetUpdate> AssetUpdates { get; set; } = new List<AssetUpdate>();

    public virtual ICollection<AssetVulnerability> AssetVulnerabilities { get; set; } = new List<AssetVulnerability>();

    public virtual ICollection<Audit> Audits { get; set; } = new List<Audit>();

    public virtual Issuance? Issuance { get; set; }

    public virtual ICollection<Issuance> Issuances { get; set; } = new List<Issuance>();

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual ICollection<Reporting> Reportings { get; set; } = new List<Reporting>();

    public virtual ICollection<Tracking> Trackings { get; set; } = new List<Tracking>();

    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();

    public virtual Vendor? Vendor { get; set; }
}

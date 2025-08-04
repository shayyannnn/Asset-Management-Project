using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class Tracking
{
    public int TrackingId { get; set; }

    public int? AssetId { get; set; }

    public string? TrackingNumber { get; set; }

    public string? RfidTag { get; set; }

    public int? LastLocationId { get; set; }

    public virtual Asset? Asset { get; set; }

    public virtual Issuance? LastLocation { get; set; }
}

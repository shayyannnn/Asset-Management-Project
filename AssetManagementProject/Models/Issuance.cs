using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class Issuance
{
    public int IssuanceId { get; set; }

    public int? EmploymentId { get; set; }

    public int? AssetId { get; set; }

    public string? IssuedTo { get; set; }

    public string? Designation { get; set; }

    public string? DepartmentId { get; set; }

    public DateOnly? DateAssigned { get; set; }

    public string? Building { get; set; }

    public string? Room { get; set; }

    public virtual Asset? Asset { get; set; }

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    public virtual ICollection<Tracking> Trackings { get; set; } = new List<Tracking>();

    public virtual ICollection<Transfer> TransferFromLocations { get; set; } = new List<Transfer>();

    public virtual ICollection<Transfer> TransferToLocations { get; set; } = new List<Transfer>();
}

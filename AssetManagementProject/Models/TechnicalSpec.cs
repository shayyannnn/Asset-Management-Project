using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class TechnicalSpec
{
    public int SpecId { get; set; }

    public string? SpecField { get; set; }

    public string? SpecName { get; set; }

    public virtual ICollection<AssetSpec> AssetSpecs { get; set; } = new List<AssetSpec>();

    public virtual ICollection<Vulnerability> Vulnerabilities { get; set; } = new List<Vulnerability>();
}

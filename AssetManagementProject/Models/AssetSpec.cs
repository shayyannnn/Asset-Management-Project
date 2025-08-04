using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class AssetSpec
{
    public int AssetSpecId { get; set; }

    public int? AssetId { get; set; }

    public int? SpecsId { get; set; }

    public virtual Asset? Asset { get; set; }

    public virtual TechnicalSpec? Specs { get; set; }
}

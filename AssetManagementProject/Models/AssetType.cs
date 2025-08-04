using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class AssetType
{
    public string AssetTypeId { get; set; } = null!;

    public string? AssetTypeDp { get; set; }

    public string? Model { get; set; }

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
}

using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class Reporting
{
    public int ReportId { get; set; }

    public int? AssetId { get; set; }

    public string? Summary { get; set; }

    public virtual Asset? Asset { get; set; }
}

using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class Maintenance
{
    public int? AssetId { get; set; }

    public int MaintenanceId { get; set; }

    public int? MaintenanceTeamId { get; set; }

    public int? MaintenanceReportId { get; set; }

    public virtual Asset? Asset { get; set; }

    public virtual ICollection<AssetUpdate> AssetUpdates { get; set; } = new List<AssetUpdate>();

    public virtual MaintenanceReport? MaintenanceReport { get; set; }

    public virtual MaintenanceTeam? MaintenanceTeam { get; set; }
}

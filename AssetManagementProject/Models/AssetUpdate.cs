using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class AssetUpdate
{
    public int? AssetId { get; set; }

    public int? MaintenanceCheck { get; set; }

    public int UpdateId { get; set; }

    public DateOnly? UpdateDate { get; set; }

    public string? UpdatedBy { get; set; }

    public string? ComponentUpdated { get; set; }

    public string? PreviousValue { get; set; }

    public string? NewValue { get; set; }

    public virtual Asset? Asset { get; set; }

    public virtual Maintenance? MaintenanceCheckNavigation { get; set; }

    public virtual ICollection<MaintenanceReport> MaintenanceReports { get; set; } = new List<MaintenanceReport>();
}

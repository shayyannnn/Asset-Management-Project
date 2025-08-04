using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class MaintenanceReport
{
    public int MaintenanceReportid { get; set; }

    public string? MaintenanceDetails { get; set; }

    public DateTime? Reportdate { get; set; }

    public int? UpdateId { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual AssetUpdate? Update { get; set; }
}

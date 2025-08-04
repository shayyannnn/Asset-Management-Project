using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class AuditReport
{
    public int AuditReportid { get; set; }

    public string? AuditDetails { get; set; }

    public DateTime? Reportdate { get; set; }

    public virtual ICollection<Audit> Audits { get; set; } = new List<Audit>();
}

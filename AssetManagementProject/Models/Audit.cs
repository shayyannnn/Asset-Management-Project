using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class Audit
{
    public int AuditId { get; set; }

    public int? AssetId { get; set; }

    public int? AuditTeamId { get; set; }

    public int? AuditReportId { get; set; }

    public virtual Asset? Asset { get; set; }

    public virtual AuditReport? AuditReport { get; set; }

    public virtual AuditTeam? AuditTeam { get; set; }
}

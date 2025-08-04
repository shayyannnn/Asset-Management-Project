using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class AuditTeam
{
    public int AuditTeamid { get; set; }

    public string? TeamMemberName { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Audit> Audits { get; set; } = new List<Audit>();
}

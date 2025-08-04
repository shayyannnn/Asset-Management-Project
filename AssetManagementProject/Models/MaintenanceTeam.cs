using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class MaintenanceTeam
{
    public int MaintenanceTeamid { get; set; }

    public string? TeamMemberName { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();
}

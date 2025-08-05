public class AssetCategoryData
{
    public string Category { get; set; }
    public int Count { get; set; }
}

public class RecentAssignmentData
{
    public string AssetName { get; set; }
    public string IssuedTo { get; set; }
    public DateOnly DateAssigned { get; set; }
}

public class SMaintenanceData
{
    public string AssetName { get; set; }
    public string Status { get; set; }
}

public class DashboardViewModel
{
    public int TotalAssets { get; set; }
    public int AssignedAssets { get; set; }
    public int UnderMaintenance { get; set; }
    public List<AssetCategoryData> AssetsByCategory { get; set; }
    public List<RecentAssignmentData> RecentAssignments { get; set; }
    public List<SMaintenanceData> MaintenanceData { get; set; } 
}

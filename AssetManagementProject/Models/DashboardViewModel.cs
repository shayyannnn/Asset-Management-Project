public class AssetCategoryData
{
    public string Category { get; set; }
    public int Count { get; set; }
}

public class DashboardViewModel
{
    public int TotalAssets { get; set; }
    public int AssignedAssets { get; set; }
    public int UnderMaintenance { get; set; }
    public List<AssetCategoryData> AssetsByCategory { get; set; }
}
using System;
using System.Collections.Generic;

namespace AssetManagementProject.Models;

public partial class Transfer
{
    public int TransferId { get; set; }

    public int? FromLocationId { get; set; }

    public int? ToLocationId { get; set; }

    public DateOnly? TransferDate { get; set; }

    public string? ApprovedBy { get; set; }

    public int? AssetId { get; set; }

    public virtual Asset? Asset { get; set; }

    public virtual Issuance? FromLocation { get; set; }

    public virtual Issuance? ToLocation { get; set; }
}
